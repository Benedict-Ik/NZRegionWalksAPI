using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;
using NZRegionWalksAPI.Repositories;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this._imageRepository = imageRepository;
        }


        // POST : api/Images/UploadImage
        [HttpPost]
        [Route("UploadImage")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDTO requestDTO)
        {
            ValidateFileUpload(requestDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Converting DTO to domain model
                var image = new Image
                {
                    File = requestDTO.File,
                    FileName = requestDTO.File.FileName,
                    FileExtension = Path.GetExtension(requestDTO.File.FileName),
                    FileSizeInBytes = requestDTO.File.Length,
                    FileDescription = requestDTO.FileDescription,
                };
                // Use repository to upload image to the database
                await _imageRepository.UploadImageAsync(image);
                return Ok(image);
            }

            catch (Exception ex) when (ex.Message.Contains("File already exists"))
            {
                return Conflict(new { Message = ex.Message });
            }


        }

        private void ValidateFileUpload(ImageUploadRequestDTO requestDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            // Validation for unsupported file extension
            if (!allowedExtensions.Contains(Path.GetExtension(requestDTO.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            // Validation for file size limit
            if (requestDTO.File.Length > 10485760) // 10MB to B
            {
                ModelState.AddModelError("file", "File size exceeds 10MB. Kindly upload a file with a smaller size.");
            }


        }
    }
}
