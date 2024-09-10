using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestRDto walkRequestRDto)
        {
            if(ModelState.IsValid)
            {
                var walkDomainModel = mapper.Map<Walk>(walkRequestRDto);
                await walkRepository.CreateAsync(walkDomainModel);

                // mapper.Map<AddWalkRequestRDto>(walkDomainModel);
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
           

        }

        [HttpGet]
        public async Task<IActionResult> GetALl([FromQuery] string? filterOn, [FromQuery] string? filterQuery,[FromQuery]string? sortBy,[FromQuery] bool isAscending )
        {
            var walkDomainModel = await walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending);

            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            if(ModelState.IsValid)
            {
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);

            if( walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto> (walkDomainModel));
        }

    }
}
