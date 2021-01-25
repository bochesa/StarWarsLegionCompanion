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
            var units = await proxy.GetAllUnits();
            var factions = await proxy.GetFactions();

            var armyListVm = new ArmyViewModel() { AvailableUnits = units, ArmyList = armyList, };

            return View(armyListVm);
        }

        [HttpGet("/edit")]
        public async Task<ActionResult> Edit(ArmyViewModel model)
        {
            
            return View(model);
        }

        [HttpPost("/edit/{id}")]
        public async Task<ActionResult> Edit(int id, ArmyViewModel model)
        {
           
            return View(model);
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
