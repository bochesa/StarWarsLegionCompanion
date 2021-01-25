using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsLegionCompanion.Site.Models;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Text;

namespace StarWarsLegionCompanion.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiProxy proxy;

        public HomeController(ILogger<HomeController> logger, ApiProxy proxy)
        {
            _logger = logger;
            this.proxy = proxy;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var apiResponse = await proxy.GetAllUnits();
            List<Unit> units = JsonConvert.DeserializeObject<List<Unit>>(apiResponse);
            var unitVm = new UnitViewModel() { AvailableUnits = units, CurrentUnits = new List<Unit>() };

            return View(unitVm);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var apiResponse = await proxy.GetFactions();
            List<Faction> factions = JsonConvert.DeserializeObject<List<Faction>>(apiResponse);


            var items = factions.Where(x => x.Id >= 0).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var armylistVm = new ArmyViewModel() { Army = new Army()};
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
            string data = JsonConvert.SerializeObject(model.Army);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json"); 
            await proxy.PostArmyList(content);

            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
