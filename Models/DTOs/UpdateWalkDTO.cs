using System.ComponentModel.DataAnnotations;

namespace NZRegionWalksAPI.Models.DTOs
{
    public class UpdateWalkDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of one hundred characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of one hundred characters")]
        public string Description { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Length has to be between 0 and 1000 km")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        // Foreign Key Relationships
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
