using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Data;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;

namespace NZRegionWalksAPI.Controllers
{
    // {baseUrl}/api/regions
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
        public IActionResult GetAllRegions()
        {
            // Get Data from Database - Domain Model 
            var regions = _dbContext.Regions.ToList();

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
        public IActionResult GetRegionById(Guid id)
        {

            // Get Data from Database - Domain Model
            var regions = _dbContext.Regions.FirstOrDefault(r => r.Id == id);

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
        public IActionResult CreateRegion([FromBody] CreateRegionDTO createRegionDTO)
        {
            // Map or convert DTO to Domain Model
            var region = new Region
            {
                Code = createRegionDTO.Code,
                Name = createRegionDTO.Name,
                RegionImageUrl = createRegionDTO.RegionImageUrl
            };

            // Use Domain Model to save to Database
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            // Map Domain Model back to DTO
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
        }
    }
}
