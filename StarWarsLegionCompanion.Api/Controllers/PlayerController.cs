using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerController : SWLBaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var dto = new InGetArmyDTO { Id = id };
            var army = await Mediator.Send(dto);
            return Ok(army);
        }
    }
}
