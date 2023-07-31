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
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            if (await _authService.Register(user)) 
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto user) 
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _authService.Login(user))
            {
                var tokenString = await _authService.GenerateTokenAsync(user);
                return Ok(new { token = tokenString });
            }
            return Unauthorized();
        }
    }
}
