using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarWarsLegionCompanion.Api.Models;
using StarWarsLegionCompanion.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Site.Controllers
{
    public class ArmyController : Controller
    {
        private readonly ApiProxy proxy;

        public ArmyController(ApiProxy proxy)
        {
            this.proxy = proxy;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var armyList = await proxy.GetArmyLists();
            //TODO: insert control for army retrievel, for authenticated user only
            return View(armyList);
        }
        //GET Edit
        [HttpGet, Route("[controller]/[action]/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            int accumulatedPointCost = 0;
            var army = await proxy.GetArmyList(id);

            var chosenunits = await proxy.GetChosenUnitByArmy(id); //chosenunit List

            var overallAvailableUnits = await proxy.GetAllUnitsByFaction(army.FactionId);
            //Sorting of units into Rank

            var armyAvailaleUnits = CheckAvailability(overallAvailableUnits, chosenunits);

            var currentUnits = ChosenUnitConverter(chosenunits, overallAvailableUnits).OrderBy(x=>x.RankId).ToList(); 
            //var armyAvailaleUnitsSorted = armyAvailaleUnits.OrderBy(x => x.RankId).ToList();

            var groupedaArmyAvailaleUnits = armyAvailaleUnits
                .GroupBy(u => u.RankId)
                .Select(grp => grp.OrderBy(x => x.Id).ToList())
                .ToList();

            var groupedacurrentUnits = currentUnits
                .GroupBy(u => u.RankId)
                .Select(grp => grp.OrderBy(x => x.Id).ToList())
                .ToList();
            foreach (var unit in currentUnits)
            {
                accumulatedPointCost += unit.PointCost;
            }
            var armyVM = new ArmyViewModel 
            { 
                Army = army, 
                ChosenUnitList = chosenunits, 
                CurrentUnits = currentUnits, 
                AvailableUnits = armyAvailaleUnits,
                AvailableUnitsGrouped = groupedaArmyAvailaleUnits,
                CurrentUnitsGrouped = groupedacurrentUnits,
                AccumulatedPointCost = accumulatedPointCost,
                //ChosenUnitListGrouped = groupedacurrentUnits
            };

            return View(armyVM);
        }
        private List<Unit> CheckAvailability( 
            List<Unit> overallAvailableUnits,
            List<ChosenUnit> chosenunits)
        {
            var armyAvailaleUnits = new List<Unit>();
            armyAvailaleUnits.AddRange(overallAvailableUnits);
            foreach (var u in overallAvailableUnits)
            {
                if (chosenunits.Exists(x => x.UnitId == u.Id) && u.IsUnique)
                    armyAvailaleUnits.Remove(u);
            }
            return armyAvailaleUnits;
        }

        //POST ADD unit to current list
        [HttpPost("[controller]/[action]/{id}")]
        public async Task<IActionResult> AddUnit(int id, int armyid)
        {
            var chosenUnit = new ChosenUnit { ArmyId = armyid, UnitId = id };
            await proxy.PostChosenUnit(chosenUnit);
            
            return RedirectToAction("Edit", new { Id = armyid });
        }

        //POST REMOVE unit from current list
        [HttpPost("[controller]/[action]/{id}")]
        public async Task<IActionResult> RemoveUnit(int id, int armyid) //id = chosen ID
        {
            await proxy.DeleteChosenUnit(id);

            return RedirectToAction("Edit", new { Id = armyid });
        }

        //GET Create View
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            //var apiResponse = await proxy.GetArmyLists();
            var factions = await proxy.GetFactions();
            var items = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "Select..." } };
            var selectedListItems = factions.Where(x => x.Id >= 0 && x.Id <20).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            items.AddRange(selectedListItems);

            var armylistVm = new ArmyViewModel() { Army = null, Factions = items};

            return View(armylistVm);
        }

        //POST Create new Army Model
        [HttpPost]
        public async Task<IActionResult> Create(ArmyViewModel model)
        {
            var factions = await proxy.GetFactions();
            if (!ModelState.IsValid)
                return View();
            var factionId = int.Parse(Request.Form["Army.Faction"]);
            if (factionId == 0 || factionId > factions.Count-1)
                return View();

            //model.Armylist.Player = new Player { Id = 3, Name = "Testi Jeff" };
            model.Army.PointLimit = 800; // Suject to chance dynamically
            model.Army.FactionId = factionId;
            var newId = await proxy.PostArmyList(model.Army);
            return RedirectToAction("Edit", new { id = newId });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await proxy.DeleteArmyList(id);
            return RedirectToAction("Index");
        }


        private List<Unit> ChosenUnitConverter(IEnumerable<ChosenUnit> chosenunits, List<Unit> availableUnits)
        {
            var unitList = new List<Unit>();
            if (availableUnits == null || chosenunits == null)
                return unitList;
            foreach (var cUnit in chosenunits)
            {
                var unit = availableUnits.FirstOrDefault(x => x.Id == cUnit.UnitId);
                unitList.Add(unit);
            }
            return unitList;
        }
    }
}
