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
using static System.Net.Mime.MediaTypeNames;

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

        [HttpGet("ApplicationHistory")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ApplicationResponseDto>))]
        public IActionResult GetApplications()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applications = _applicationRepository.GetApplications(userId);
            return Ok(_mapper.Map<List<ApplicationResponseDto>>(applications));
        }

        [HttpGet("{applicationId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CompleteApplicationResponseDto>))]
        public IActionResult GetApplications(Guid applicationId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var application = _applicationRepository.GetApplication(applicationId);
            if (application.StudentId != userId)
            {
                return Unauthorized();
            } 
            return Ok(_mapper.Map<CompleteApplicationResponseDto>(application));
        }
    }
}
