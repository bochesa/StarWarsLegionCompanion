using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StarWarsLegionCompanion.Api.Models;
using StarWarsLegionCompanion.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            var apiResponseArmyList = await proxy.GetArmyLists();
            List<ArmyList> armyList = JsonConvert.DeserializeObject<List<ArmyList>>(apiResponseArmyList);
            var apiResponseUnits = await proxy.GetAllUnits();
            List<Unit> units = JsonConvert.DeserializeObject<List<Unit>>(apiResponseUnits);

            var armyListVm = new ArmyViewModel() { AvailableUnits = units, ArmyLists = armyList, };

            return View(armyListVm);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(ArmyViewModel model)
        {
            
            return View(model);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Edit(int id, ArmyViewModel model)
        {
           
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var apiResponse = await proxy.GetArmyLists();
            List<ArmyList> factions = JsonConvert.DeserializeObject<List<ArmyList>>(apiResponse);


            var items = factions.Where(x => x.Id >= 0).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var armylistVm = new ArmyViewModel() { Armylist = new ArmyList() };
            armylistVm.Factions = items;

            return View(armylistVm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ArmyViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            //model.Armylist.Player = new Player { Id = 3, Name = "Testi Jeff" };
            model.Armylist.PointLimit = 800;
            model.Armylist.FactionId = int.Parse(Request.Form["ArmyList.Faction"]);
            string data = JsonConvert.SerializeObject(model.Armylist);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await proxy.PostArmyList(content);

            return RedirectToAction("Index");
        }
    }
}
