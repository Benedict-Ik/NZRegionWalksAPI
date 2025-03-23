using Microsoft.AspNetCore.Identity;

namespace NZRegionWalksAPI.Repositories
{
    public interface ITokenRepository
    {
        Task<string> GenerateJWTTokenAsync(IdentityUser user, List<string> roles);
    }
}
