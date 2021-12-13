using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UpgradeController : SWLBaseController
    {
        // GET: api/<UpgradeController>
        [HttpGet]
        public async Task<IActionResult> GetAllUpgrades()
        {
            var upgrades = await Mediator.Send(new InGetAllUpgradesDTO());
            return Ok(upgrades);
        }

        // GET api/<UpgradeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UpgradeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UpgradeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpgradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
