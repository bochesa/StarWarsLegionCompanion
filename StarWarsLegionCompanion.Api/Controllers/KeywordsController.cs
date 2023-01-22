using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtilityLibrary.Application.Handlers;

namespace StarWarsLegionCompanion.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class KeywordsController : SWLBaseController
    {
        // GET: /<KeywordsController>
        [HttpGet]
        public async Task<IActionResult> GetAllKeywords()
        {
            var keywords = await Mediator.Send(new InGetAllKeywordsDTO());
            return Ok(keywords);
        }
    }
}
