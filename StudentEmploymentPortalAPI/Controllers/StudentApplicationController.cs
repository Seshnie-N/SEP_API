using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.Data.Entity;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentApplicationController(IWebHostEnvironment webHostEnvironment, IStudentApplicationRepository applicationRepository, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost("CreateApplication", Name = "CreateApplication")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Consumes("multipart/form-data")]
        public IActionResult CreateApplication([FromForm] ApplicationDto applicationDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (applicationDto == null)
                return BadRequest();
            
            /*Fetching application with same JobPostId and StudentId as parsed through the DTO if it already exists*/
            var application = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == applicationDto.JobPostId && c.StudentId == userId)
                .FirstOrDefault();

            /*Checking if application already exists*/
            if (application != null) 
            {
                ModelState.AddModelError("", "Application already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            /*Mapping the data parsed through DTO to a StudentApplication object*/
            var applicationMap = _mapper.Map<StudentApplication>(applicationDto);

            /*Updating the StudentApplication object's StudentId to the current logged in UserId*/
            applicationMap.StudentId = userId; 

            /*Posting the new application and accounting for it failing to post*/
            if (!_applicationRepository.CreateApplication(applicationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            
            //Begin processing and storing documents
            var files = applicationDto.Files;
            var fileNames = applicationDto.DocumentName;
            /*Checking if file/files have been uploaded with the application*/
            if (files != null && files.Count > 0 && fileNames != null && fileNames.Count > 0)
            {
                application = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == applicationDto.JobPostId && c.StudentId == userId)
                .FirstOrDefault();

                if (application != null)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        var file = files[i];
                        if (file != null && file.Length > 0)
                        {
                            if (!uploadDocument(file, application.Id, fileNames[i]))
                            {
                                ModelState.AddModelError("", "Something went wrong while saving document/s.");
                                return StatusCode(500, ModelState);
                            }
                        }
                    }
                    return Ok("Successfully created application and uploaded documents");
                }
            }
            //End processing and storing documents

            return Ok("Application submitted successfully");
        }

        [HttpPost("AddApplicationDocument", Name = "AddApplicationDocument")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Consumes("multipart/form-data")]
        public IActionResult AddApplicationDocument([FromForm] DocumentDto documentDto)
        {
            var files = documentDto.Files;
            var fileNames = documentDto.DocumentName;
            /*Checking if file/files have been uploaded with the application*/
            if (files != null && files.Count > 0 && fileNames != null && fileNames.Count > 0)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var application = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == documentDto.JobPostId && c.StudentId == userId)
                .FirstOrDefault();

                if (application != null)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        var file = files[i];
                        if (file != null && file.Length > 0)
                        {
                            if(!uploadDocument(file, application.Id, fileNames[i]))
                            {
                                ModelState.AddModelError("", "Something went wrong while saving document/s.");
                                return StatusCode(500, ModelState);
                            }
                        }
                    }
                    return Ok("Successfully uploaded documents");
                }
                else
                {
                    ModelState.AddModelError("", "No application exists with given job post");
                    return StatusCode(500, ModelState);
                }
            }
            return Ok("No files were submitted to upload");
        }

        private bool uploadDocument(IFormFile file, Guid applicationId, string DocumentName)
        {
            var uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            var applicationDocument = new ApplicationDocument
            {
                StudentApplicationId = applicationId,
                Name = DocumentName,
                FilePath = uniqueFileName,
                UploadDate = DateTime.Now
            };

            if (!_applicationRepository.AddDocument(applicationDocument))
            {
                return false;
            }
            return true;
        }
    }
}
