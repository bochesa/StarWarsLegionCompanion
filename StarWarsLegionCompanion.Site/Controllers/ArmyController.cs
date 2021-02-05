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
        public async Task<ActionResult> Edit(int id, int chosenunitid = 0, int upgradecategory = 0)
        {
            int accumulatedPointCost = 0;
            List<Upgrade> availableUpgrades = new List<Upgrade>();
            List<Upgrade> currentUpgrades = new List<Upgrade>();
            List<ChosenUpgrade> chosenUpgrades = new List<ChosenUpgrade>();

            var army = await proxy.GetArmyList(id);
            var chosenunits = await proxy.GetChosenUnitByArmy(id); //chosenunit List
            var overallAvailableUnits = await proxy.GetAllUnitsByFaction(army.FactionId);
            var overallAvailavleUpgrades = await proxy.GetAllUpgrades();
            if (chosenunitid != 0)
            {

                var overallupgrades = await proxy.GetAllUpgradesByCategory(upgradecategory);

                foreach (ChosenUnit cUnit in chosenunits)
                {
                    var cunitUpgrade = await proxy.GetChosenUpgradeByChosenUnit(cUnit.Id);
                    if (cunitUpgrade != null)
                        chosenUpgrades.AddRange(cunitUpgrade);
                }
                currentUpgrades = ChosenConverter(chosenUpgrades, overallAvailavleUpgrades).ToList();

                if (overallupgrades.Count != 0 && chosenUpgrades.Count != 0)
                {
                    availableUpgrades = CheckAvailability(overallupgrades, chosenUpgrades);
                    foreach (var upgrade in currentUpgrades)
                    {
                        accumulatedPointCost += upgrade.PointCost;
                    }
                }
            }
            //Sorting of units into Rank
            var armyAvailaleUnits = CheckAvailability(overallAvailableUnits, chosenunits);

            var currentUnits = ChosenConverter(chosenunits, overallAvailableUnits).OrderBy(x => x.RankId).ToList();
            //var armyAvailaleUnitsSorted = armyAvailaleUnits.OrderBy(x => x.RankId).ToList();

            var groupedaChosenUnits = chosenunits
                .GroupBy(u => u.UnitRankId)
                .Select(grp => grp.OrderBy(x => x.Id).ToList())
                .ToList();

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
                ChosenUnitsGrouped = groupedaChosenUnits,
                CurrentUnits = currentUnits,
                AvailableUnits = armyAvailaleUnits,
                AvailableUnitsGrouped = groupedaArmyAvailaleUnits,
                CurrentUnitsGrouped = groupedacurrentUnits,
                AccumulatedPointCost = accumulatedPointCost,
                ChosenUpgrades = chosenUpgrades,
                AvailableUpgrades = availableUpgrades,
                CurrentUpgrades = currentUpgrades,
                ChosenUnitId = chosenunitid,
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

        private List<Upgrade> CheckAvailability(
           List<Upgrade> overallAvailableUpgrades,
           List<ChosenUpgrade> chosenupgrades)
        {
            var armyAvailaleUpgrades = new List<Upgrade>();
            armyAvailaleUpgrades.AddRange(overallAvailableUpgrades);
            foreach (var u in overallAvailableUpgrades)
            {
                if (chosenupgrades.Exists(x => x.UpgradeId == u.Id))
                    armyAvailaleUpgrades.Remove(u);
            }
            return armyAvailaleUpgrades;
        }
        [HttpPost("[controller]/[action]/{id}")]
        public async Task<IActionResult> AddUpgrade(int id, int chosenunitid, int upgradeid) //id = Army Id
        {
            //Add upgrade to ChosenUnit
            var chosenUpgrade = new ChosenUpgrade { ChosenUnitId = chosenunitid, UpgradeId = upgradeid };
            await proxy.PostChosenUpgrade(chosenUpgrade);

            return RedirectToAction("Edit", new { Id = id });
        }
        //POST REMOVE upgrade from current list
        [HttpPost("[controller]/[action]/{id}")]
        public async Task<IActionResult> RemoveUpgrade(int id, int armyid) //id = chosen ID
        {
            await proxy.DeleteChosenUpgrade(id);

            return RedirectToAction("Edit", new { Id = armyid });
        }
        //POST ADD unit to current list
        [HttpPost("[controller]/[action]/{id}")]
        public async Task<IActionResult> AddUnit(int id, int armyid, int rankid)
        {
            var chosenUnit = new ChosenUnit { ArmyId = armyid, UnitId = id, UnitRankId = rankid };
            //get unit 
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
            var selectedListItems = factions.Where(x => x.Id >= 0 && x.Id < 20).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            items.AddRange(selectedListItems);

            var armylistVm = new ArmyViewModel() { Army = null, Factions = items };

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
            if (factionId == 0 || factionId > factions.Count - 1)
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

        private List<Upgrade> ChosenConverter(IEnumerable<ChosenUpgrade> chosenUpgrades, List<Upgrade> availableUpgrades)
        {
            var upgradelist = new List<Upgrade>();
            if (availableUpgrades == null || chosenUpgrades == null)
                return upgradelist;
            foreach (var cUnit in chosenUpgrades)
            {
                var upgrade = availableUpgrades.FirstOrDefault(x => x.Id == cUnit.UpgradeId);
                upgradelist.Add(upgrade);
            }
            return upgradelist;
        }
        private List<Unit> ChosenConverter(IEnumerable<ChosenUnit> chosenunits, List<Unit> availableUnits)
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
