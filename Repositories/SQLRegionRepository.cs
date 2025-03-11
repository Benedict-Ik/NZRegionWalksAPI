using Microsoft.EntityFrameworkCore;
using NZRegionWalksAPI.Data;
using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private NZRegionWalksDbContext _dbContext;

        public SQLRegionRepository(NZRegionWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: {baseUrl}/api/regions
        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            var regions = await _dbContext.Regions.ToListAsync();
            return (regions);
        }

        // GET: {baseUrl}/api/regions/{id}
        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            return (region);
        }

        // POST: {baseUrl}/api/regions
        public async Task<Region?> CreateRegionAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return (region);
        }

        // PUT: {baseUrl}/api/regions/{id}
        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var updateRegion = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            // Check if region is null
            if (updateRegion == null)
            {
                return null;
            }

            // Update the region
            updateRegion.Code = region.Code;
            updateRegion.Name = region.Name;
            updateRegion.RegionImageUrl = region.RegionImageUrl;
            await _dbContext.SaveChangesAsync();

            // Return the updated region
            return (updateRegion);
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var deleteRegion = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            // Check if region is null
            if (deleteRegion == null)
            {
                return null;
            }
            _dbContext.Regions.Remove(deleteRegion);
            await _dbContext.SaveChangesAsync();
            return (deleteRegion);
        }
    }
}
