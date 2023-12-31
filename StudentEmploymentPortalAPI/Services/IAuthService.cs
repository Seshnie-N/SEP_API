﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterDto user);
        Task<bool> Login(LoginDto user);
        Task<string> GenerateTokenAsync(LoginDto user);
    }
}
