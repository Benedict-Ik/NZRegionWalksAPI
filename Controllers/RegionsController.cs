using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Data;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;
using NZRegionWalksAPI.Repositories;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZRegionWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;

        public RegionsController(NZRegionWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this._dbContext = dbContext;
            this._regionRepository = regionRepository;
        }

        /* GET ALL REGIONS */
        // GET: {baseUrl}/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Get Data from Database - Domain Model 
            var regions = await _regionRepository.GetAllRegionsAsync();
            //var regions = await _dbContext.Regions.ToListAsync();

            // Map Domain Model to DTO
            var regionsDTO = new List<RegionDTO>();

            // Loop through the domain model and converting each individual property to a DTO. We looped through because of the list of regions
            foreach (var region in regions)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            // Return DTO to Client
            return Ok(regionsDTO);
        }

        /* GET REGION BY ID */
        // GET: {baseUrl}/api/regions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            // Get Data from Database - Domain Model
            var region = await _regionRepository.GetRegionByIdAsync(id);
            // Check if region is null
            if (region == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };
            // Return DTO to Client
            return Ok(regionDTO);
        }

        /* CREATE REGION */
        // POST: {baseUrl}/api/regions
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionDTO createRegionDTO)
        {
            // Mapping DTO to domain model
            var region = new Region()
            {
                Code = createRegionDTO.Code,
                Name = createRegionDTO.Name,
                RegionImageUrl = createRegionDTO.RegionImageUrl,
            };

            //if (region == null)
            //{
            //    return NotFound();
            //}

            // Use the repository to save the domain model to the database
            region = await _regionRepository.CreateRegionAsync(region);

            // Mapping domain model to DTO
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };

            // Return DTO to Client
            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, regionDTO);

        }

        /* UPDATE REGION */
        // PUT: {baseUrl}/api/regions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            // Get Data from Database - Domain Model
            var region = await _regionRepository.GetRegionByIdAsync(id);

            // Check if region is null
            if (region == null)
            {
                return NotFound();
            }

            // Mapping DTO to domain model
            region.Code = updateRegionDTO.Code;
            region.Name = updateRegionDTO.Name;
            region.RegionImageUrl = updateRegionDTO.RegionImageUrl;

            // Use the repository to update the domain model in the database
            region = await _regionRepository.UpdateRegionAsync(id, region);

            // Mapping domain model to DTO
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };
            // Return DTO to Client
            return Ok(regionDTO);
        }

        /* DELETE REGION */
        // DELETE: {baseUrl}/api/regions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            // Get Data from Database - Domain Model
            var region = await _regionRepository.GetRegionByIdAsync(id);
            // Check if region is null
            if (region == null)
            {
                return NotFound();
            }
            // Use the repository to delete the domain model from the database
            region = await _regionRepository.DeleteRegionAsync(id);

            // Mapping domain model to DTO
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };

            // Return DTO to Client
            return Ok(new
            {
                Message = "Below record has been deleted Successfully:",
                regionDTO
            });
        }
    }
}