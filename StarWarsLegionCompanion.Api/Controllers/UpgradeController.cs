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
    public class UpgradeController : ControllerBase
    {

        private readonly DataContext context;

        public UpgradeController(DataContext context)
        {
            this.context = context;
        }
        #region GET Actions
        /// <summary>
        /// Get All Upgrades
        /// </summary>
        /// <returns>List of sorted upgrades</returns>
        [HttpGet]
        public IActionResult GetAllUpgrades()
        {
            var upgrades = context.Upgrades.Include(u => u.Keywords).ToList();

            return Ok(upgrades);
        }
        /// <summary>
        /// Get All upgrades in specified faction by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Category/{id}")]
        public IActionResult GetAllUpgradesByCategory(int id)
        {

            var upgrades = context.Upgrades.Where(x => x.UpgradeCategoryId == id).Include(u => u.Keywords);


            return Ok(upgrades);
        }
        [HttpGet("{id}")]
        public IActionResult GetUpgradeById(int id)
        {
            Upgrade upgrade = context.Upgrades
                .Where(u => u.Id == id)
                .Include(u => u.Keywords)
                .FirstOrDefault()
                ;

            if (upgrade == null)
                return NotFound();
            return Ok(upgrade);
        }

        #endregion



        #region POST Actions
        [HttpPost]
        public IActionResult PostUpgrade(Upgrade upgrade)
        {
            context.Upgrades.Add(upgrade);
            context.SaveChanges();
            return CreatedAtAction("GetUpgradeById", new { id = upgrade.Id }, upgrade);
        }

        #endregion

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
