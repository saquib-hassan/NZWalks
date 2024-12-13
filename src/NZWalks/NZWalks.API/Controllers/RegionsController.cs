using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
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
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await dbContext.Regions.ToListAsync();

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
        public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequestDTO )
        {
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDTO.Name,
                Code = addRegionRequestDTO.Code,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl,

            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionDtos = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetByID), new {id = regionDtos.Id}, regionDtos);

        }

        [HttpPut]
        [Route("{id:Guid}")]

        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

           var regionDomainModel =  dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomainModel is null)
            {
                return NotFound();
            }

            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            //dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionDtos = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDtos);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(x=>x.Id == id);

            if( region == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(region);
            dbContext.SaveChanges();

            var regionDto = new RegionDTO()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl,
            };
            return Ok(regionDto);
        }
    }
}
//b1cd4ea1-b3e1-4645-71c2-08dd1ad558c3