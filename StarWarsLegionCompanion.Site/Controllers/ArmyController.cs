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
            var units = await proxy.GetAllUnits();
            var armyList = await proxy.GetArmyLists();

            var armyListVm = new ArmyViewModel() { AvailableUnits = units, ArmyList = armyList, };

            return View(armyListVm);
        }

        [HttpGet, Route("[controller]/[action]/{id}")]
        public async Task<ActionResult> Edit(int id, ArmyViewModel model = null)
        {
            if (model == null)
                model = new ArmyViewModel();
            var armylist = await proxy.GetArmyList(id);
            var availableUnits = await proxy.GetAllUnits(); 
            availableUnits.Where(x => x.FactionId == armylist.FactionId).ToList();
            model.AvailableUnits = availableUnits;
            model.Army = armylist;

            return View(model);
        }

        [HttpPost("AddUnit/{unitid}")]
        public async Task<IActionResult> AddUnit(int armyid, int unitid)
        {
            var armyListVm = new ArmyViewModel() { AvailableUnits = await proxy.GetAllUnits(), Army = new Army { Units = new List<Unit>() } };
            var unit = await proxy.GetUnit(unitid);

            armyListVm.Army.Units.Add(unit);
            armyListVm.AvailableUnits.Remove(unit);

            return RedirectToAction("Edit", new { Id = armyid, model= armyListVm });
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var apiResponse = await proxy.GetArmyLists();
            var factions = await proxy.GetFactions();

            var items = factions.Where(x => x.Id >= 0).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var armylistVm = new ArmyViewModel() { Army = new Army() };
            armylistVm.Factions = items;

            return View(armylistVm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ArmyViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            //model.Armylist.Player = new Player { Id = 3, Name = "Testi Jeff" };
            model.Army.PointLimit = 800;
            model.Army.FactionId = int.Parse(Request.Form["ArmyList.Faction"]);

            await proxy.PostArmyList(model.Army);

            return RedirectToAction("Edit", new { Id = model.Army.Id });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //IMPLEMENT DELETE LIST WITH POST CALL TO API
            return View();
        }
    }
}
