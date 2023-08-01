using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ICVRepository _CVRepository;

        public CVController(ICVRepository CVRepository)
        {
            _CVRepository = CVRepository;
           
        }

        //GET: api/Student/
        [HttpGet("Get Student profile")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudent(Guid StudentId)
        {
            var Student = _CVRepository.GetStudent(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            return Ok(Student);
        }

        //GET: api/Qualifications/
        [HttpGet("Get Qualifications")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Qualification>))]
        public IActionResult GetQualifications(Guid StudentId)
        {
            var Qualifications = _CVRepository.GetQualifications(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Qualifications);
        }

        //GET: api/Qualification/
        [HttpGet("Get Qualification")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Qualification>))]
        public IActionResult GetQualification(int QualificationId)
        {
            var Qualification = _CVRepository.GetQualification(QualificationId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(Qualification);
        }
        //GET: api/Experiences/
        [HttpGet("Get Experiences")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        public IActionResult GetExperiences(Guid StudentId)
        {
            var Experiences = _CVRepository.GetExperiences(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Experiences);
        }
        //GET: api/Experience/
        [HttpGet("Get Experience")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        public IActionResult GetExperience(int ExperienceId)
        {
            var Experience = _CVRepository.GetExperience(ExperienceId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(Experience);
        }

        //GET: api/Referees/
        [HttpGet("Get Referees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Referee>))]
        public IActionResult GetReferees(Guid StudentId)
        {
            var Referees = _CVRepository.GetReferees(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Referees);
        }

        //GET: api/Referee/
        [HttpGet("Get Referee")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Referee>))]
        public IActionResult GetReferee(int RefereeId)
        {
            var Referee = _CVRepository.GetExperience(RefereeId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(Referee);
        }

    }
}