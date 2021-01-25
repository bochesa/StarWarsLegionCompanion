﻿using Microsoft.AspNetCore.Http;
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
            FillInArmyLists(armyList);
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
        public IActionResult PostArmyList(Army armyList)
        {
            context.ArmyLists.Add(armyList);
            context.SaveChanges();
            return CreatedAtAction("GetArmyList", new { id = armyList.Id }, armyList);
        }

        //Support method for filling in objects from foreign keys.
        void FillInArmyLists(IEnumerable<Army> list)
        {
            foreach (var armyList in list)
            {
                armyList.Player = context.Players.FirstOrDefault(x => x.Id == armyList.PlayerId);
                armyList.Faction = context.Factions.FirstOrDefault(x => x.Id == armyList.FactionId);
            }
        }
    }
}

