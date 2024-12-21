using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly NZWalksDbContext dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, NZWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.contextAccessor = contextAccessor;
            this.dbContext = dbContext;
        }
        public async Task<Image> UploadAsync(Image image)
        {

            // uploading image to local path
            var localstoragePath = Path.Combine(webHostEnvironment.ContentRootPath,"Images",$"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localstoragePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // uploading image to url
            //  http://localhost:7291/images/image.jpg 

            var urlFilePath = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}{contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();
            return image;
        }
    }
}
