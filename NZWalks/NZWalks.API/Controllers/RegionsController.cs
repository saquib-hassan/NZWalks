﻿using Azure.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using System.ComponentModel.DataAnnotations;

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

            var regionDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }

            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regionsDomain = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (regionsDomain == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id = regionsDomain.Id,
                Name = regionsDomain.Name,
                Code = regionsDomain.Code,
                RegionImageUrl = regionsDomain.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody]AddRegionRequestDto addRegionRequestDto)
        {

            var regionDomainModel = new Region
            {
                //I'm taking the data from dto and passing it to model
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                //after saving the data into db, I'm againg passing
                //it to the user through dto
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            
            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }



        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute]Guid id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //we're updating existing elements, not creating one.
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
          

            dbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);

        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {

            var regionDomainModel = dbContext.Regions.FirstOrDefault(x=>x.Id == id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

            //option if we want to return the deleted region back
            //pass the dtos again

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok();

        }

    }

}
