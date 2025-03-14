using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;
using NZRegionWalksAPI.Repositories;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this._mapper = mapper;
            this._walkRepository = walkRepository;
        }

        /*CREATE WALKS*/
        //POST: {baseUrl}/api/walks
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] CreateWalkDTO createWalkDTO)
        {
            // Mapping DTO to Domain Model
            var walk = _mapper.Map<Walk>(createWalkDTO);

            // Create Walk - Calling Repository
            walk = await _walkRepository.CreateWalkAsync(walk);

            // Mapping Domain Model to DTO
            var walkDTO = _mapper.Map<WalkDTO>(walk);

            // Return DTO to Client
            return Ok(walkDTO);
        }


        /*GET WALKS*/
        // GET: {baseUrl}/api/walks
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            // Calling Repository
            var walks = await _walkRepository.GetAllWalksAsync();

            // Mapping Domain Model to DTO
            var walksDTO = _mapper.Map<List<WalkDTO>>(walks);
            return Ok(walksDTO);
        }
    }
}
