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
    public class ArmyController : SWLBaseController
    {
        // GET: /<ArmyController>
        [HttpGet]
        public async Task<IActionResult> GetAllArmies()
        {
            var armies = await Mediator.Send(new InGetAllArmiesDTO());
            return Ok(armies);
        }

        // GET /<ArmyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArmy(int id)
        {
            var dto = new InGetArmyDTO { Id = id };
            var army = await Mediator.Send(dto);
            return Ok(army);
        }

        // POST /<ArmyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InPostNewArmyDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }

        // Post /Army/AddCommand
        [HttpPost("AddCommand")]
        public async Task<IActionResult> AddCommand([FromBody] InAddArmyCommandDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }
        // Post /Army/RemoveCommand
        [HttpPost("AddCommand")]
        public async Task<IActionResult> RemoveCommand([FromBody] InRemoveArmyCommandDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }

        // PUT api/<ArmyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArmyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
