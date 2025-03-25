using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Models.DTOs;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImagesController()
        {

        }


        // POST : api/Images/UploadImage
        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDTO requestDTO)
        {
            ValidateFileUpload(requestDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Use repository to upload image to the database
            return Ok();
        }

        private void ValidateFileUpload(ImageUploadRequestDTO requestDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(requestDTO.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (requestDTO.File.Length > 10485760) // 10MB to B
            {
                ModelState.AddModelError("file", "File size exceeds 10MB. Kindly upload a file with a smaller size.");
            }
        }
    }
}
