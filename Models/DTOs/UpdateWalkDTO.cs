namespace NZRegionWalksAPI.Models.DTOs
{
    public class UpdateWalkDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        // Foreign Key Relationships
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
