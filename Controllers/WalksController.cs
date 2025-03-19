using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.CustomActionFilters;
using NZRegionWalksAPI.Models.Domain;
using NZRegionWalksAPI.Models.DTOs;
using NZRegionWalksAPI.Repositories;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this._mapper = mapper;
            this._walkRepository = walkRepository;
        }


        /* GET WALKS */
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

        /* GET WALKS BY ID */
        // GET: {baseUrl}/api/walks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            // Calling Repository
            var walk = await _walkRepository.GetWalkByIdAsync(id);

            // Check if walk is null
            if (walk == null)
            {
                return NotFound();
            }

            // Mapping Domain Model to DTO
            return Ok(_mapper.Map<WalkDTO>(walk));
        }


        /* CREATE WALKS */
        //POST: {baseUrl}/api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] CreateWalkDTO createWalkDTO)
        {
            // Mapping DTO to Domain Model
            var walk = _mapper.Map<Walk>(createWalkDTO);

            // Create Walk - Calling Repository
            walk = await _walkRepository.CreateWalkAsync(walk);

            // Mapping Domain Model to DTO
            var walkDTO = _mapper.Map<CreateWalkDTO>(walk);

            // Return DTO to Client
            return Ok(walkDTO);
            //return Ok(walkDTO);
        }


        /* UPDATE WALKS */
        // PUT: {baseUrl}/api/walks/{id}
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, UpdateWalkDTO updateWalkDTO)
        {
            // Map DTO to domain
            var walk = _mapper.Map<Walk>(updateWalkDTO);

            if (walk == null)
            {
                return NotFound();
            }

            walk = await _walkRepository.UpdateWalkAsync(id, walk);


            // Map back to DTO to present to client
            //var walkDTO = _mapper.Map<WalkDTO>(walk);
            var walkDTO = _mapper.Map<UpdateWalkDTO>(walk);
            return Ok(walkDTO);
        }

        // DELETE: {baseUrl}/api/walks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            // Calling Repository
            var deleteWalk = await _walkRepository.GetWalkByIdAsync(id);

            if (deleteWalk == null)
            {
                return NotFound();
            }

            deleteWalk = await _walkRepository.DeleteWalkAsync(id);

            // Mapping Domain Model to DTO
            var deletedWalk = _mapper.Map<WalkDTO>(deleteWalk);
            //return Ok(_mapper.Map<WalkDTO>(deleteWalk));
            return Ok(new
            {
                message = "Walk deleted Successfully",
                body = deletedWalk
            });
        }
    }
}