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
        // Delete /Army/RemoveCommand
        [HttpDelete("RemoveCommand")]
        public async Task<IActionResult> RemoveCommand([FromBody] InRemoveArmyCommandDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }

        // Post /Army/AddChosenUnit
        [HttpPost("AddChosenUnit")]
        public async Task<IActionResult> AddChosenUnit([FromBody] InAddArmyChosenUnitDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }
        // Delete /Army/RemoveChosenUnit
        [HttpDelete("RemoveChosenUnit")]
        public async Task<IActionResult> RemoveChosenUnit([FromBody] InRemoveArmyChosenUnitDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }
        // Post /Army/AddChosenUpgrade
        [HttpPost("AddChosenUpgrade")]
        public async Task<IActionResult> AddChosenUpgrade([FromBody] InAddArmyChosenUpgradeDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }

        // Delete /Army/RemoveChosenUpgrade
        [HttpDelete("RemoveChosenUpgrade")]
        public async Task<IActionResult> RemoveChosenUpgrade([FromBody] InRemoveArmyUpgradeDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }
    }
}
