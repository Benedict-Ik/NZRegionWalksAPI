using Microsoft.EntityFrameworkCore;
using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Data
{
    public class NZRegionWalksDbContext : DbContext
    {
        public NZRegionWalksDbContext(DbContextOptions<NZRegionWalksDbContext> options) : base(options) { }

        /* Tables in the database */
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties table
            var difficulties = new List<Difficulty>()
            {
                new Difficulty { Id = Guid.Parse("09acb658-9fb7-4cb9-a2cc-507236c088f4"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("4c736a86-7e36-4ad5-b228-f807d8cddd33"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("c7656a0a-8d3a-459f-8f54-fdfca219afb0"), Name = "Hard" }
            };
            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions table
            var regions = new List<Region>()
            {
                new Region { Id = Guid.Parse("0126ad40-97c6-4082-8b2f-0088a644156c"), Code = "AUK", Name = "Auckland", RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/auckland/auckland-region.jpg" },
                new Region { Id = Guid.Parse("071f8490-aa7c-47e7-9313-2bd79a5542de"), Code = "WLG", Name = "Wellington", RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/wellington/wellington-region.jpg" },
                new Region { Id = Guid.Parse("2ff92ecb-1eba-4424-9f5c-f5a8361ddb5c"), Code = "CAN", Name = "Canterbury", RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/canterbury/canterbury-region.jpg" },
                new Region { Id = Guid.Parse("41981686-7482-4c4a-9dd9-5125868a25cf"), Code = "OTA", Name = "Otago", RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/otago/otago-region.jpg" },
                new Region { Id = Guid.Parse("7754f540-1fe9-4e27-aa90-08af22acb110"), Code = "STL", Name = "Southland", RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/southland/southland-region.jpg" },
                new Region { Id = Guid.Parse("a4a43444-236e-4a70-9c6a-5f5dd75966b4"), Code = "WKO", Name = "Waikato", RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/waikato/waikato-region.jpg" }
            };
            // Seed regions to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}