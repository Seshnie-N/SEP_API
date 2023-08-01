using AutoMapper;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetApplication()
        {
            var applications = _mapper.Map<List<StudentApplication>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }*/
        
        [HttpPost] 
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApplication([FromBody] ApplicationDto applicationDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //Will get the currently logged in user waiting on merge with IdentityUser implemented first
            System.Diagnostics.Debug.WriteLine("This is current logged in user's ID: " + userId);
            
            if (applicationDto == null)
                return BadRequest();

            var category = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == applicationDto.JobPostId && c.StudentId == applicationDto.StudentId)
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Application already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var applicationMap = _mapper.Map<StudentApplication>(applicationDto);

            if (!_applicationRepository.CreateApplication(applicationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
