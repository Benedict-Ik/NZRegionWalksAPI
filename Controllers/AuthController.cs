using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZRegionWalksAPI.Models.DTOs;
using NZRegionWalksAPI.Repositories;

namespace NZRegionWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this._userManager = userManager;
            this._tokenRepository = tokenRepository;
        }

        // POST: api/Auth/Register 
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username,
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                // Add roles to the user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered successfully.");
                    }
                }
            }
            return BadRequest("Something went wrong.");
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var identityUser = await _userManager.FindByEmailAsync(loginRequestDTO.Username);
            if (identityUser != null && await _userManager.CheckPasswordAsync(identityUser, loginRequestDTO.Password))
            {
                // Get Roles for user
                var roles = await _userManager.GetRolesAsync(identityUser);

                if (roles != null)
                {
                    var jwtToken = _tokenRepository.GenerateJWTTokenAsync(identityUser, roles.ToList());

                    // Anon Object
                    //return Ok(new
                    //{
                    //    message = "User logged in successfully.",
                    //    response = jwtToken
                    //});

                    var response = new LoginResponseDTO
                    {
                        JWTToken = await jwtToken
                    };
                    return Ok(response);
                }
                //return Ok("User logged in successfully.");
            }
            return BadRequest("Invalid login details.");
        }
    }
}
