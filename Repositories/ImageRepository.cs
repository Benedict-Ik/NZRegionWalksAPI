using NZRegionWalksAPI.Data;
using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly NZRegionWalksDbContext _dbContext;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZRegionWalksDbContext dbContext)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            this._dbContext = dbContext;
        }

        public async Task<Image> UploadImageAsync(Image image)
        {
            //var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", image.FileName, image.FileExtension);
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", image.FileName);

            // Validation to check if the file already exists
            if (File.Exists(localFilePath))
            {
                throw new Exception("File already exists");
            }

            // Upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // Construct the URL path for the image
            //var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}/{image.FileExtension}";
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}";

            image.FilePath = urlFilePath;

            // Saving changes to the database
            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}
