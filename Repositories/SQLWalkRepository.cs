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
    }
}