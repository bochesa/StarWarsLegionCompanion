using UtilityLibrary.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;
using UtilityLibrary.Data.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UnitController : SWLBaseController
    {
        private readonly IUnitOfWork uow;

        public UnitController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET: api/<UnitController>
        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var units = await Mediator.Send(new InGetAllUnitsDTO());
            return Ok(units);
        }

        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnit(int id)
        {
            var dto = new InGetUnitDTO { Id = id };
            var unit = await Mediator.Send(dto);
            return Ok(unit);
        }

        // POST api/<UnitController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InPostNewUnitDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }

        // Patch /<UnitController/5
        [HttpPatch("UpdateUnitName")]
        public async Task<IActionResult> UpdateUnit(InUpdateUnitNameDTO request)
        {
            var affectedLines = await Mediator.Send(request);
            return Ok(affectedLines);
        }
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateUnit(int id, JsonPatchDocument<Unit> unitUpdates)
        //{
        //    var unit = await uow.Units.Get(id);

        //    if (unit == null)
        //    {
        //        return NotFound();
        //    }

        //    unitUpdates.ApplyTo(unit);
        //    await uow.Complete();
        //    return Ok(unit);
        //}

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
