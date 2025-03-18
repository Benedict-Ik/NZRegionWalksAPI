using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.CustomActionFilters;
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
        private readonly IMapper mapper;

        public RegionsController(NZRegionWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._regionRepository = regionRepository;
            this.mapper = mapper;
        }

        /* GET ALL REGIONS */
        // GET: {baseUrl}/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Get Data from Database - Domain Model 
            var regions = await _regionRepository.GetAllRegionsAsync();


            // Using AutoMapper to map Domain Model to DTO
            var regionsDTO = mapper.Map<IEnumerable<RegionDTO>>(regions);

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

            // Using AutoMapper to map Domain Model to DTO
            var regionDTO = mapper.Map<RegionDTO>(region);

            // Return DTO to Client
            return Ok(regionDTO);
        }

        /* CREATE REGION */
        // POST: {baseUrl}/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionDTO createRegionDTO)
        {
            // Mapping DTO to domain model
            var region = mapper.Map<Region>(createRegionDTO);

            // Use the repository to save the domain model to the database
            region = await _regionRepository.CreateRegionAsync(region);

            // Using AutoMapper to map Domain Model to DTO
            var regionDTO = mapper.Map<RegionDTO>(region);

            // Return DTO to Client
            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, regionDTO);

        }

        /* UPDATE REGION */
        // PUT: {baseUrl}/api/regions/{id}
        [HttpPut("{id}")]
        [ValidateModel]
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
            var regionDomain = mapper.Map<Region>(updateRegionDTO);

            // Use the repository to update the domain model in the database
            region = await _regionRepository.UpdateRegionAsync(id, regionDomain);

            // Mapping domain model to DTO
            var regionDTO = mapper.Map<RegionDTO>(region);

            return Ok(new
            {
                Message = "Below record has been updated Successfully:",
                regionDTO
            });
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
            var regionDTO = mapper.Map<RegionDTO>(region);

            // Return DTO to Client
            return Ok(new
            {
                Message = "Below record has been deleted Successfully:",
                regionDTO
            });
        }
    }
}