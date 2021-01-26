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
            var army = await proxy.GetArmyList(id);

            var chosenunits = await proxy.GetAllChosenUnits();
            var query = chosenunits.Where(x => x.ArmyId == id);

            var availableUnits = await proxy.GetAllUnits();
            availableUnits.Where(x => x.FactionId == army.FactionId);
            

            var currentUnits = ChosenUnitConverter(chosenunits, availableUnits);
            var armyVM = new ArmyViewModel { Unit = null, Army = army, ChosenUnitList = chosenunits, CurrentUnits = currentUnits, AvailableUnits = availableUnits };

            return View(armyVM);
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

            var items = factions.Where(x => x.Id >= 0).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var armylistVm = new ArmyViewModel() { Army = null, Factions = items};
            armylistVm.Factions = items;

            return View(armylistVm);
        }

        //POST Create new Army Model
        [HttpPost]
        public async Task<IActionResult> Create(ArmyViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            //model.Armylist.Player = new Player { Id = 3, Name = "Testi Jeff" };
            model.Army.PointLimit = 800;
            model.Army.FactionId = int.Parse(Request.Form["Army.Faction"]);
            await proxy.PostArmyList(model.Army);
            var armies = await proxy.GetArmyLists();
            var newArmy = armies.FirstOrDefault(x => x.Name == model.Army.Name);
            return RedirectToAction("Edit", new { id = newArmy.Id });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //IMPLEMENT DELETE LIST WITH POST CALL TO API
            return View();
        }
        private List<Unit> ChosenUnitConverter(IEnumerable<ChosenUnit> chosenunits, List<Unit> availableUnits)
        {
            var unitList = new List<Unit>();
            foreach (var cUnit in chosenunits)
            {
                var unit = availableUnits.FirstOrDefault(x => x.Id == cUnit.UnitId);
                unitList.Add(unit);
            }
            return unitList;
        }
    }
}
