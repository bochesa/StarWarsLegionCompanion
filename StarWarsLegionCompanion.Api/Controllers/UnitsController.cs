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
        #region GET Actions
        /// <summary>
        /// Get All Units
        /// </summary>
        /// <returns>List of sorted units</returns>
        [HttpGet]
        public IActionResult GetAllUnits()
        {
            var qeuryunits = context.Units
                .Include(u => u.Weapons)
                .ThenInclude(k => k.AttackDie)
                .Include(u => u.Weapons)
                .ThenInclude(k => k.Keywords)
                .Include(u => u.Keywords)
                .Include(u => u.UpgradeCategories)
                ;

            var units = qeuryunits.OrderBy(u => u.RankId).ToList();


            FillInObjectsForList(units);

            return Ok(units);
        }
        /// <summary>
        /// Get All units in specified faction by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("faction/{id}")]
        public IActionResult GetAllUnitsByFaction(int id)
        {

            var qeuryunits = context.Units.Where(x => x.FactionId == id)
                .Include(u => u.Weapons).ThenInclude(k => k.AttackDie)
                .Include(u => u.Weapons).ThenInclude(k => k.Keywords)
                .Include(u => u.Keywords)
                .Include(u => u.UpgradeCategories)
                ;


            var units = qeuryunits.OrderBy(u => u.RankId).ToList();

            FillInObjectsForList(units);

            return Ok(units);
        }
        [HttpGet("{id}")]
        public IActionResult GetUnitById(int id)
        {
            Unit unit = context.Units.Where(u => u.Id == id)
                .Include(u => u.Weapons).ThenInclude(k => k.AttackDie)
                .Include(u => u.Weapons).ThenInclude(k => k.Keywords)
                .Include(u => u.Keywords)
                .Include(u => u.UpgradeCategories)
                .FirstOrDefault()
                ;

            FillInObjects(unit);

            if (unit == null)
                return NotFound();
            return Ok(unit);
        }

        #endregion



        #region POST Actions
        [HttpPost]
        public IActionResult PostUnit(Unit unit)
        {
            context.Units.Add(unit);
            context.SaveChanges();
            return CreatedAtAction("GetUnitById", new { id = unit.Id }, unit);
        }

        #endregion

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

        void FillInObjectsForList(List<Unit> units)
        {
            foreach (var unit in units)
            {
                unit.Faction = context.Factions.FirstOrDefault(f => f.Id == unit.FactionId);
                unit.Rank = context.Ranks.FirstOrDefault(r => r.Id == unit.RankId);
                unit.UnitType = context.UnitTypes.FirstOrDefault(r => r.Id == unit.UnitTypeId);
                unit.AttackSurge = context.AttackSurges.FirstOrDefault(r => r.Id == unit.AttackSurgeId);
                foreach (var unitweap in unit.Weapons)
                {
                    unitweap.RangeType = context.RangeTypes.FirstOrDefault(x => x.Id == unitweap.RangeTypeId);
                }

            }
        }
        void FillInObjects(Unit unit)
        {
            unit.Faction = context.Factions.FirstOrDefault(f => f.Id == unit.FactionId);
            unit.Rank = context.Ranks.FirstOrDefault(r => r.Id == unit.RankId);
            unit.UnitType = context.UnitTypes.FirstOrDefault(r => r.Id == unit.UnitTypeId);
            unit.AttackSurge = context.AttackSurges.FirstOrDefault(r => r.Id == unit.AttackSurgeId);
            foreach (var unitweap in unit.Weapons)
            {
                unitweap.RangeType = context.RangeTypes.FirstOrDefault(x => x.Id == unitweap.RangeTypeId);
            }
        }
    }
}
