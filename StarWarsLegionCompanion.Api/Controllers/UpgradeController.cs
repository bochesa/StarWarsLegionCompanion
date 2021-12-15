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
        public async Task<IActionResult> GetUpgrade(int id)
        {
            var upgrade = await Mediator.Send(new InGetUpgradeDTO { Id = id });
            return Ok(upgrade);
        }

        // POST api/<UpgradeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InPostNewUpgradeDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
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
