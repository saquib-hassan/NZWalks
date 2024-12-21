using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        [HttpPost("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto requestDto)
        {

            ValidateFileUpload(requestDto);

            if(ModelState.IsValid)
            {
                // convert dto to domain

                var imageDomainModel = new Image
                {
                    File = requestDto.File,
                    FileName = requestDto.FileName,
                    FileDescription = requestDto.FileDescription,
                    FileExtension = Path.GetExtension(requestDto.File.FileName),
                    FileSizeInBytes = requestDto.File.Length
                };

                // repository

                await imageRepository.UploadAsync(imageDomainModel);
                return Ok(imageDomainModel);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto requestDto)
        {

            var allowedExtensions = new string[] { ".jpeg", ".jpg", ".png" };
            if(!allowedExtensions.Contains(Path.GetExtension(requestDto.File.FileName)))
            {
                ModelState.AddModelError("file","Unsupported File");
            }

            if(allowedExtensions.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10MB, Please Upload less than 10MB");
            }
        }

    }
}



