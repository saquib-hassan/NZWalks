using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regionsDomain = dbContext.Regions.ToList();

            var regionDtos = new List<RegionDTO>();
            foreach(var regionDomain in regionsDomain)
            {
                regionDtos.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });

            }
            return Ok(regionDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetByID([FromRoute]Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDtos = new RegionDTO()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };
            
            return Ok(regionDtos);
        }

        [HttpPost]
        public IActionResult Create(RegionDTO regionDTO)
        {
            
        }

        
    }
}
