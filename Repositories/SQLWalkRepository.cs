using Microsoft.EntityFrameworkCore;
using NZRegionWalksAPI.Data;
using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZRegionWalksDbContext _dbContext;

        public SQLWalkRepository(NZRegionWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            //var walks = await _dbContext.Walks.ToListAsync();
            var walks = await _dbContext.Walks.Include(w => w.Difficulty).Include(w => w.Region).ToListAsync();
            return walks;
        }


        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            var walk = await _dbContext.Walks
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .FirstOrDefaultAsync(w => w.Id == id);
            return walk;
        }


        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }


        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;
            var updatedWalk = existingWalk;
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Walks
                .Include(w => w.Difficulty) // Nav Property
                .Include(w => w.Region) // Nav Property
                .FirstOrDefaultAsync(w => w.Id == id);
        }


        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var deletedRegion = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

            // Check if region is null
            if (deletedRegion == null)
            {
                return null;
            }

            _dbContext.Walks.Remove(deletedRegion);
            _dbContext.SaveChanges();
            return deletedRegion;
        }
    }
}