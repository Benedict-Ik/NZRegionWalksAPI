using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);
    }
}
