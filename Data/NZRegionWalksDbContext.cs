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

    }
}
