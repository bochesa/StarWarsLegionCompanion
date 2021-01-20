﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsLegionCompanion.Site.Models;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<ActionResult> Index()
        {
            var apiResponse = await proxy.GetAllUnits();
            List<Unit> units = JsonConvert.DeserializeObject<List<Unit>>(apiResponse);
            return View(units);
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