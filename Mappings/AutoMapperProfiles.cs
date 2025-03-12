using AutoMapper;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;

namespace NZRegionWalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, CreateRegionDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();
            CreateMap<CreateWalkDTO, Walk>().ReverseMap();
        }
    }
}
