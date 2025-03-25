using System.ComponentModel.DataAnnotations;

namespace NZRegionWalksAPI.Models.DTOs
{
    public class ImageUploadRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
