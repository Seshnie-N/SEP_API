using AutoMapper;
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
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }

            return Ok(posts);
        }

        // GET api/JobPosts/5
        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(JobPost))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult GetJobPost(int postId)
        {
            var post = _jobPostRepository.GetJobPost(postId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (post == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Ok(post);
        }

        
    }
}
