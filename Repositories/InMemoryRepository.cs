using NZRegionWalksAPI.Models.Domain;

namespace NZRegionWalksAPI.Repositories
{
    public class InMemoryRepository : IRegionRepository
    {
        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "AUK",
                    Name = "Auckland",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/auckland/auckland-landscape-2.jpg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "WLG",
                    Name = "Wellington",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/wellington/wellington-landscape-1.jpg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "CAN",
                    Name = "Canterbury",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/canterbury/canterbury-landscape-1.jpg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "OTA",
                    Name = "Otago",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/otago/otago-landscape-1.jpg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "STL",
                    Name = "Southland",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/southland/southland-landscape-1.jpg"
                }
            };
        }

        Task<Region> IRegionRepository.CreateRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.DeleteRegionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.GetRegionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.UpdateRegionAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
