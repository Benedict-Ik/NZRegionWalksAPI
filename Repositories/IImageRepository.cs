using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadImageAsync(Image image);
    }
}
