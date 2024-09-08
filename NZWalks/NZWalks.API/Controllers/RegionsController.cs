using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "ALC",
                    RegionImageUrl="https://images.pexels.com/photos/19517677/pexels-photo-19517677/free-photo-of-new-zealand-city-view.jpeg"
                },

                new Region
                {
                    Id= Guid.NewGuid(),
                    Name= "Welington",
                    Code= "WLG",
                    RegionImageUrl="https://images.pexels.com/photos/27623562/pexels-photo-27623562/free-photo-of-a-city-street-at-night-with-a-long-exposure.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
               
            };
            return Ok(regions);
        }
    }
}
