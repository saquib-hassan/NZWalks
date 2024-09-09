using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        public WalkController(IWalkRepository walkRepository)
        {
            
        }
        [HttpPost]
        public async Task<IActionResult>Create(Walk walk)
        {

        }
    }
}
