using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomValidationFilter;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody]AddWalkRequestDto addWalkRequestDto)
        {
            //dto to domain
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto); 
            await walkRepository.CreateAsync(walkDomainModel);
            //domain to dto
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
            
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var walkDomainModel = await walkRepository.GetAllAsync();
            //domain to dto
            //var walkDto = mapper.Map<List<WalkDto>>(walkDomainModel);

            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }

        [HttpGet("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            //dto to domain
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel= await walkRepository.UpdateAsync(walkDomainModel,id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel)); 
        }

        [HttpDelete("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);
            if( walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
