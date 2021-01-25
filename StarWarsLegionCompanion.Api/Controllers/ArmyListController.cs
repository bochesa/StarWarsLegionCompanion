using Microsoft.AspNetCore.Http;
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
    public class ArmyListController : ControllerBase
    {
        private readonly DataContext context;

        public ArmyListController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetArmyList()
        {
            var armyList = context.ArmyLists.ToList();

            return Ok(armyList);
        }
        [HttpGet("{id}")]
        public IActionResult GetArmyList(int id)
        {
            var armyList = context.ArmyLists.FirstOrDefault(x => x.Id == id);
            
            if (armyList == null)
                return NotFound();

            return Ok(armyList);
        }


        [HttpPost]
        public IActionResult PostArmyList(ArmyList armyList)
        {
            context.ArmyLists.Add(armyList);
            context.SaveChanges();
            return CreatedAtAction("GetArmyList", new { id = armyList.Id }, armyList);
        }


    }
}

