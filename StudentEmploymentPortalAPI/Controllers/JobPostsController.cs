using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public ActionResult GetJobPosts()
        {
            var posts = _jobPostRepository.GetJobPosts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
        public ActionResult Get(int postId)
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
