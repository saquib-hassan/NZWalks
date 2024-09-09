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
        public async Task<IActionResult> Create(AddWalkRequestRDto walkRequestRDto)
        {
            var walkDomainModel = mapper.Map<Walk>(walkRequestRDto);
            await walkRepository.CreateAsync(walkDomainModel);

            // mapper.Map<AddWalkRequestRDto>(walkDomainModel);
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        [HttpGet]
        public Task<List<IActionResult>> GetALl()
        {

        }
    }
}
