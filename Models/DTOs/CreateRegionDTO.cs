using System.ComponentModel.DataAnnotations;

namespace NZRegionWalksAPI.Models.DTOs
{
    public class CreateRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of three characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of three characters")]

        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of one hundred characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
