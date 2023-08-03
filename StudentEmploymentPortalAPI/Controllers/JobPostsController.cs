﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class JobPostsController : ControllerBase
    {
        private readonly IJobPostRepository _jobPostRepository;
        private readonly IMapper _mapper;

        public JobPostsController(IJobPostRepository jobPostRepository, IMapper mapper)
        {
            _jobPostRepository = jobPostRepository;
            _mapper = mapper;
        }
        // GET: api/JobPosts
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobPost>))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> GetJobPosts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var posts = await _jobPostRepository.GetJobPostsAsync(userId);
            if (posts.Count == 0)
                return NoContent();
            var mapped = _mapper.Map<List<JobPostDto>>(posts);
            return Ok(_mapper.Map<List<JobPostDto>>(posts));
        }

        // GET api/JobPosts/5
        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(JobPost))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult GetJobPost(Guid postId)
        {
            if (!_jobPostRepository.JobPostExists(postId))
                return NotFound();

            var post = _jobPostRepository.GetJobPost(postId);

            return Ok(_mapper.Map<JobPostDto>(post));
        }

        
    }
}
