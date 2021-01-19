using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly DataContext context;

        public UnitsController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetUnits()
        {
            var qeuryunits = context.Units
                .Include(u => u.Weapons).ThenInclude(k=>k.Keywords)
                .Include(u => u.Keywords)
                ;
            var units = qeuryunits.ToList();

            return Ok(units);
        }
        [HttpGet("{id}")]
        public IActionResult GetUnit(int id)
        {
            var unit = context.Units
                 .Where(u=>u.Id == id)
                 .Include(u => u.Weapons).ThenInclude(k => k.Keywords)
                 .Include(u => u.Keywords)
                 ;

            if (unit == null)
                return NotFound();
            return Ok(unit);
        }
        [HttpPost]
        public IActionResult PostUnit(Unit unit)
        {
            context.Units.Add(unit);
            context.SaveChanges();
            return CreatedAtAction("GetUnit", new { id = unit.Id }, unit);

        }
        [HttpPut("{id}")]
        public IActionResult PutUnit([FromRoute] int id, [FromBody] Unit unit)
        {
            if (id != unit.Id)
                return BadRequest();
            context.Entry(unit).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (context.Units.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Unit> DeleteUnit(int id)
        {
            var unit = context.Units.Find(id);
            if (unit == null)
                return NotFound();
            context.Units.Remove(unit);
            context.SaveChanges();
            return unit;
        }
    }
}
