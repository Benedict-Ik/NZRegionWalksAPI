using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZRegionWalksAPI.Data;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZRegionWalksDbContext _dbContext;

        public RegionsController(NZRegionWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /* GET ALL REGIONS */
        // GET: {baseUrl}/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Get Data from Database - Domain Model 
            var regions = await _dbContext.Regions.ToListAsync();

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

        /* GET SINGLE REGION BY ID */
        // GET: {baseUrl}/api/regions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {

            // Get Data from Database - Domain Model
            var regions = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (regions == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var regionsDTO = new RegionDTO()
            {
                Id = regions.Id,
                Code = regions.Code,
                Name = regions.Name,
                RegionImageUrl = regions.RegionImageUrl,
            };

            // Return DTO to Client
            return Ok(regionsDTO);
        }

        /* CREATE REGION */
        // POST: {baseUrl}/api/regions
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionDTO createRegionDTO)
        {
            // Map or convert DTO to Domain Model
            var region = new Region
            {
                Code = createRegionDTO.Code,
                Name = createRegionDTO.Name,
                RegionImageUrl = createRegionDTO.RegionImageUrl
            };

            // Use Domain Model to save to Database
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            // Map Domain Model back to DTO
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, regionDTO);
        }

        // PUT: {baseUrl}/api/regions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateRegionDTO updateRegionDTO)
        {
            // Check if the data exists in DB
            var region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            // Mapping the DTO to the Domain Model
            region.Code = updateRegionDTO.Code;
            region.Name = updateRegionDTO.Name;
            region.RegionImageUrl = updateRegionDTO.RegionImageUrl;

            // Because _dbContext is already tracking the changes, we don't need to call the Update method
            _dbContext.SaveChanges();

            // Mapping the Domain Model back to the DTO to return to the client
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDTO);
        }

        // DELETE: {baseUrl}/api/regions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            // Check if the data exists in DB
            var region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            //return NoContent();
            return Ok("Deleted successfully");
        }
    }
}
