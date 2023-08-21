using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ICollection<JobPostDto>>> GetJobPosts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var posts = await _jobPostRepository.GetJobPostsAsync(userId);
            if (posts.Count == 0)
                return NoContent();
            return Ok(_mapper.Map<List<JobPostDto>>(posts));
        }

        // GET api/JobPosts/5
        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<JobPostDto> GetJobPost(Guid postId)
        {
            if (!_jobPostRepository.JobPostExists(postId))
                return NotFound();

            var post = _jobPostRepository.GetJobPost(postId);

            return Ok(_mapper.Map<JobPostDto>(post));
        }

        
    }
}
