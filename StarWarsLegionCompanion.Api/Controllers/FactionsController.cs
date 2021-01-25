using Microsoft.AspNetCore.Mvc;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FactionsController : Controller
    {
        private readonly DataContext context;

        public FactionsController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetFactions()
        {
            var qeuryunits = context.Factions;
                
            var factions = qeuryunits.ToList();
            return Ok(factions);
        }
        [HttpGet("{id}")]
        public IActionResult GetFaction(int id)
        {
            var faction = context.Factions.Where(u => u.Id == id);

            if (faction == null)
                return NotFound();
            return Ok(faction);
        }
    }
}
