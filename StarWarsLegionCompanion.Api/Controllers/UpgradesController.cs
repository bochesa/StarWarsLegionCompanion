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
    public class UpgradesController : ControllerBase
    {
        private readonly DataContext context;

        public UpgradesController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetUpgrade()
        {
            var queryable = context.Upgrades
                .Include(e=>e.Factions)
                //.Include(e => e.Keywords)
                ;
            var upgrades = queryable.ToList();
            return Ok(upgrades);
        }
        [HttpGet("{id}")]
        public IActionResult GetUpgrade(int id)
        {
            var product = context.Units.Find(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public IActionResult PostUpgrade(Upgrade upgrade)
        {
            context.Upgrades.Add(upgrade);
            context.SaveChanges();
            return CreatedAtAction("GetUpgrade", new { id = upgrade.Id }, upgrade);

        }
        [HttpPut("{id}")]
        public IActionResult PutUpgrade([FromRoute] int id, [FromBody] Upgrade upgrade)
        {
            if (id != upgrade.Id)
                return BadRequest();
            context.Entry(upgrade).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (context.Upgrades.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Upgrade> DeleteUpgrade(int id)
        {
            var upgrade = context.Upgrades.Find(id);
            if (upgrade == null)
                return NotFound();
            context.Upgrades.Remove(upgrade);
            context.SaveChanges();
            return upgrade;
        }
    }
}
