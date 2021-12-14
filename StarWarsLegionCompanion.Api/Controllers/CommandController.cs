using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : SWLBaseController
    {
        // GET: api/<CommandController>
        [HttpGet]
        public async Task<IActionResult> GetAllCommands()
        {
            var units = await Mediator.Send(new InGetAllCommandsDTO());
            return Ok(units);
        }

        // GET api/<CommandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommandController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
