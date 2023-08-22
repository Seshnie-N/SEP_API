using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;
using StudentEmploymentPortalAPI.Services;
using System.Net;

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Register(user);
            if (result.Succeeded) 
                return Ok("Registration successful");

            return BadRequest(result);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginDto user) 
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _authService.Login(user))
            {
                var tokenString = await _authService.GenerateTokenAsync(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
    }
}
