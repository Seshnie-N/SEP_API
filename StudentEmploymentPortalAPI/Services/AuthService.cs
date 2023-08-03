using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace StudentEmploymentPortalAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IStudentRepository _studentRepository;

        public AuthService(UserManager<ApplicationUser> userManager,IConfiguration config, IStudentRepository studentRepository)
        {
            _userManager = userManager;
            _config = config;
            _studentRepository = studentRepository;
        }

        public async Task<bool> Register(RegisterDto user)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(applicationUser, user.Password);
            if (result.Succeeded)
            {                
                await _userManager.AddToRoleAsync(applicationUser, "User");
                _studentRepository.Create(await _userManager.GetUserIdAsync(applicationUser), user);
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginDto user)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            if (applicationUser == null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(applicationUser, user.Password);
        }

        public async Task<string> GenerateTokenAsync(LoginDto user)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            //add claims
            IEnumerable<System.Security.Claims.Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            //ensure that the token is not tampered with on the client side
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(
                claims:claims, 
                expires: DateTime.Now.AddMinutes(_config.GetSection("JWT:DurationInMinutes").Get<double>()),
                issuer: _config.GetSection("JWT:Issuer").Value,
                audience: _config.GetSection("JWT:Audience").Value,
                signingCredentials: signingCred);
 
            return new JwtSecurityTokenHandler().WriteToken(securityToken);    
        }
    }
}
