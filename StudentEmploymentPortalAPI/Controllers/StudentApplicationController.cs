using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.Net;
using System.Security.Claims;

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentApplicationController : ControllerBase
    {
        private readonly IStudentApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        public StudentApplicationController(IStudentApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        /*[HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StudentApplication>))]
        public IActionResult GetApplications()
        {
            var applications = _mapper.Map<List<StudentApplication>>(_applicationRepository.GetApplications());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(applications);
        }*/

        [HttpPost] 
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApplication([FromBody] ApplicationDto applicationDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            System.Diagnostics.Debug.WriteLine("This is current logged in user's ID: " + userId);
            
            if (applicationDto == null)
                return BadRequest();
            
            /*Fetching application with same JobPostId and StudentId as parsed through the DTO if it already exists*/
            var category = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == applicationDto.JobPostId && c.StudentId == userId)
                .FirstOrDefault();

            if (category != null) /*Checking if application already exists*/
            {
                ModelState.AddModelError("", "Application already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var applicationMap = _mapper.Map<StudentApplication>(applicationDto); /*Mapping the data parsed through DTO to a StudentApplication object*/
            applicationMap.StudentId = userId; /*Updating the StudentApplication object's StudentId to the current logged in UserId*/
            if (!_applicationRepository.CreateApplication(applicationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
