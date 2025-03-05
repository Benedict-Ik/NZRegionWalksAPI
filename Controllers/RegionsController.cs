using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Data;

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
        // GET: {baseUrl}/api/regions
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            /*Hardcoded*/
            /*var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region.jpg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region.jpg"
                }
            };*/

            var regions = _dbContext.Regions.ToList();
            return Ok(regions);
        }
        // GET: {baseUrl}/api/regions/{id}
        [HttpGet("{id}")]
        //[Route("{id: Guid}")]
        //public IActionResult GetRegionById([FromRoute]Guid id)
        public IActionResult GetRegionById(Guid id)
        {
            var region = _dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }
    }
}
