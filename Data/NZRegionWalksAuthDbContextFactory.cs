using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NZRegionWalksAPI.Data
{
    public class NZRegionWalksAuthDbContextFactory : IDesignTimeDbContextFactory<NZRegionWalksAuthDbContext>
    {
        public NZRegionWalksAuthDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NZRegionWalksAuthDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("NZRegionWalksAuthConnection"));

            return new NZRegionWalksAuthDbContext(optionsBuilder.Options);
        }
    }
}