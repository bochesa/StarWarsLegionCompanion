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
    public class KeywordsController : ControllerBase
    {

        private readonly DataContext context;

        public KeywordsController(DataContext context)
        {
            this.context = context;
        }

        #region GET Actions
        /// <summary>
        /// Get All Keywords
        /// </summary>
        /// <returns>List of sorted Keywords by Name</returns>
        [HttpGet]
        public IActionResult GetAllKeywords()
        {
            var keywords = context.Keywords.OrderBy(u => u.Name).ToList();

            return Ok(keywords);
        }

        //TODO GetAllKeywordsExtended (a list of all keywords including units and weapons - for references)

        [HttpGet("{id}")]
        public IActionResult GetKeywordById(int id)
        {
            var keyword = context.Keywords.Where(u => u.Id == id);

            if (keyword == null)
                return NotFound();
            return Ok(keyword);
        }

        #endregion

        #region POST Actions
        [HttpPost]
        public IActionResult PostKeyword(Keyword keyword)
        {
            context.Keywords.Add(keyword);
            context.SaveChanges();
            return CreatedAtAction("GetUnitById", new { id = keyword.Id }, keyword);
        }

        #endregion

        [HttpPut("{id}")]
        public IActionResult PutUnit([FromRoute] int id, [FromBody] Keyword keyword)
        {
            if (id != keyword.Id)
                return BadRequest();
            context.Entry(keyword).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (context.Keywords.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Keyword> DeleteUnit(int id)
        {
            var keyword = context.Keywords.Find(id);
            if (keyword == null)
                return NotFound();
            context.Keywords.Remove(keyword);
            context.SaveChanges();
            return keyword;
        }
    }
}
