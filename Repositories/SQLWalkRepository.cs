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

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _dbContext.AddAsync(walk);
            _dbContext.SaveChanges();
            return walk;
        }


        public async Task<List<Walk>> GetAllWalksAsync()
        {
            //var walks = await _dbContext.Walks.ToListAsync();
            var walks = await _dbContext.Walks.Include(w => w.Difficulty).Include(w => w.Region).ToListAsync();
            return walks;
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            var walk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
            return walk;
        }
    }
}