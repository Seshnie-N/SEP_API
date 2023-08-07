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
        public IActionResult CreateApplication([FromBody] ApplicationDto applicationDto)
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

            //begin test pdf
            string pdfFilePath = @"C:\Users\A0079419\OneDrive - University of Witwatersrand\Documents\Test.pdf";
            byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);

            IFormFile pdfFile = new FormFile(new MemoryStream(pdfBytes), 0, pdfBytes.Length, "pdfFile", "Test.pdf");
            List<IFormFile> files = new List<IFormFile>();
            files.Add(pdfFile);
            List<string> documentNames = new List<string>();
            documentNames.Add("Test");

            application = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == applicationDto.JobPostId && c.StudentId == userId)
                .FirstOrDefault();

            AddApplicationDocument(files, documentNames, application.Id);
            //end test pdf
            
            /*File/Files have been uploaded with the application*//*
            if (applicationDto.Files != null && applicationDto.Files.Count > 0) 
            {
                application = _applicationRepository.GetApplications()
                .Where(c => c.JobPostId == applicationDto.JobPostId && c.StudentId == userId)
                .FirstOrDefault();

                if (application != null) *//*application exists and we can link the uploaded documents with it*//*
                {
                    AddApplicationDocument(applicationDto.Files, applicationDto.DocumentName, application.Id);
                }
            }*/
            
            return Ok("Successfully created");
        }

        [HttpPost("AddApplicationDocument", Name = "AddApplicationDocument")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddApplicationDocument(List<IFormFile> files, List<string> DocumentName, Guid ApplicationId)
        {
            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    if (file != null && file.Length > 0)
                    {
                        var uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        var filePath = Path.Combine(uploadsPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var application = _applicationRepository.GetApplications().Where(c => c.Id == ApplicationId).FirstOrDefault();

                        if (application != null)
                        {
                            var applicationDocument = new ApplicationDocument
                            {
                                StudentApplicationId = ApplicationId,
                                Name = DocumentName[i],
                                FilePath = uniqueFileName,
                                UploadDate = DateTime.Now
                            };

                            if (!_applicationRepository.AddDocument(applicationDocument))
                            {
                                ModelState.AddModelError("", "Something went wrong while saving document/s.");
                                return StatusCode(500, ModelState);
                            }
                        }
                    }
                }

                return Ok("Successfully created");
            }

            return Ok("Successfully created");
        }
    }
}
