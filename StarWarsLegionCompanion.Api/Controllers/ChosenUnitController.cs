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
    public class ChosenUnitController : ControllerBase
    {

        private readonly DataContext context;

        public ChosenUnitController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get the full List of Chosen units
        /// </summary>
        /// <remarks>
        /// Useful method during development
        /// </remarks>
        /// <returns>The the full list of Chosen Units in the Database</returns>
        [HttpGet]
        public IActionResult GetAllChosenUnits()
        {
            var chosenUnits = context.ChosenUnits.OrderBy(x => x.UnitRankId);

            return Ok(chosenUnits);
        }
        /// <summary>
        /// Get a chosen Unit from its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Chosen Unit object with the Id specified by the parameter</returns>
        [HttpGet("{id}")]
        public IActionResult GetChosenUnitById(int id)
        {
            var chosenUnit = context.ChosenUnits.FirstOrDefault(x => x.Id == id);

            return Ok(chosenUnit);
        }
        [HttpGet("army/{id}")]
        public IActionResult GetChosenUnitByArmy(int id) //faction Id
        {
            var chosenUnit = context.ChosenUnits.Where(x => x.ArmyId == id).OrderBy(x => x.UnitRankId);

            return Ok(chosenUnit);
        }

        /// <summary>
        /// Post new Chosen Unit object to database in Json Format
        /// </summary>
        /// <remarks>
        /// Example:
        ///     {
        ///         "id": 1, *Optional, will be autogenerated*
        ///         "armyid": 1, //reference to armylist by id
        ///         "unitid": 1, //reference to Unit by id
        ///     }
        ///     
        /// </remarks>
        /// <param name="chosenUnit"></param>
        /// <returns>The Newly created object as Json</returns>
        [HttpPost]
        public IActionResult PostChosenUnit([FromBody] ChosenUnit chosenUnit)
        {
            context.ChosenUnits.Add(chosenUnit);
            context.SaveChanges();
            return CreatedAtAction("GetChosenUnitById", new { id = chosenUnit.Id }, chosenUnit);
        }

        [HttpDelete("{id}")]
        public ActionResult<ChosenUnit> DeleteChosenUnit(int id)
        {
            var unit = context.ChosenUnits.Find(id);
            if (unit == null)
                return NotFound();
            context.ChosenUnits.Remove(unit);
            context.SaveChanges();
            return unit;
        }
    }
}
