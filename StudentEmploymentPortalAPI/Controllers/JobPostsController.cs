using Microsoft.AspNetCore.Mvc;
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

        public JobPostsController(IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
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

        /*// GET api/<JobPostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobPostsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobPostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobPostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
