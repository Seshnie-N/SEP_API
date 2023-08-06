using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using StudentEmploymentPortalAPI.Repository;

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ICVRepository _CVRepository;
        private readonly IMapper _mapper;

        public CVController(ICVRepository CVRepository, IMapper mapper)
        {
            _CVRepository = CVRepository;
            _mapper = mapper;

        }
        //POST METHODS

        //#Student

        [HttpPost("AddStudent/{Student}")]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Here, you would perform any additional validation or business logic as needed.
            // For example, checking if the provided IdNumber or Email already exists, etc.

            // If everything is valid, add the student to the repository and save changes.
            _CVRepository.AddStudent(student);
            _CVRepository.SaveChanges();

            // Return the newly created student with a 201 Created status.
            return CreatedAtAction(nameof(GetStudent), new { id = student.UserId }, student);
        }

        // PUT: api/Students/UpdateStudent/{studentId}
        [HttpPut("UpdateStudent/{studentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateStudent(Guid studentId, Student updatedStudent)
        {
            try
            {
                _CVRepository.UpdateStudent(studentId, updatedStudent);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //#Referee

        // POST: api/Students/AddReferee/{studentId}
        [HttpPost("AddReferee/{studentId}")]
        [ProducesResponseType(201, Type = typeof(Referee))]
        [ProducesResponseType(400)]
        public IActionResult AddReferee(Guid studentId, Referee referee)
        {
            try
            {
                _CVRepository.AddReferee(studentId, referee);
                return CreatedAtAction(nameof(GetStudent), new { id = studentId }, referee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/Students/UpdateReferee/{studentID}/{refereeId}
        [HttpPut("{studentId}/UpdateReferee/{refereeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateReferee(Guid studentId, int refereeId, Referee referee)
        {
            try
            {
                _CVRepository.UpdateReferee(studentId, refereeId, referee);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut("WithdrawReferee/{RefereeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult WithdrawReferee(int RefereeId)
        {
            try
            {
                _CVRepository.WithdrawReferee(RefereeId);
                return Content("Referee Withdrawn Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //#Qualification

        // POST: api/Students/AddQualification/{studentId}
        [HttpPost("{studentId}/AddQualification")]
        [ProducesResponseType(201, Type = typeof(Qualification))]
        [ProducesResponseType(400)]
        public IActionResult AddQualification(Guid studentId, Qualification qualification)
        {
            try
            {
                _CVRepository.AddQualification(studentId, qualification);
                return CreatedAtAction(nameof(GetStudent), new { id = studentId }, qualification);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Students/UpdateQualification/{studentId}/{qualificationId}
        [HttpPut("{studentId}/UpdateQualification/{qualificationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQualification(Guid studentId, int qualificationId, Qualification qualification)
        {
            try
            {
                _CVRepository.UpdateQualification(studentId, qualificationId, qualification);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("WithdrawQualification/{qualificationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult WithdrawQualification(int qualificationId)
        {
            try
            {
                _CVRepository.WithdrawQualification(qualificationId);
                return Content("Qualification withdrawn Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //#Experience

        // POST: api/Students/AddExperience/{studentId}
        [HttpPost("{studentId}/AddExperience")]
        [ProducesResponseType(201, Type = typeof(Experience))]
        [ProducesResponseType(400)]
        public IActionResult AddExperience(Guid studentId, Experience experience)
        {
            try
            {
                _CVRepository.AddExperience(studentId, experience);
                return CreatedAtAction(nameof(GetStudent), new { id = studentId }, experience);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Students/UpdateExperience/{studentId}/{experienceId}
        [HttpPut("{studentId}/UpdateExperience/{experienceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateExperience(Guid studentId, int experienceId, Experience experience)
        {
            try
            {
                _CVRepository.UpdateExperience(studentId, experienceId, experience);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut("WithdrawExperience/{ExperienceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult WithdrawExperience(int ExperienceId)
        {
            try
            {
                _CVRepository.WithdrawExperience(ExperienceId);
                return Content("Experience Withdrawn Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get Methods


        //GET: api/Student/
        [HttpGet("Get Student CV")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetCV(Guid StudentId)
        {


            var Student = _CVRepository.GetCV(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentCVDto = _mapper.Map<Student, StudentCVDto>(Student);

            return Ok(studentCVDto);
        }
        [HttpGet("Get Student profile")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudent(Guid StudentId)
        {


            var Student = _CVRepository.GetStudentProfile(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentProfileDto = _mapper.Map<Student, StudentProfileDto>(Student);

            return Ok(studentProfileDto);
        }

        //GET: api/Qualifications/
        [HttpGet("Get Qualifications")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Qualification>))]
        public IActionResult GetQualifications(Guid StudentId)
        {
            var Qualifications = _CVRepository.GetQualifications(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var qualificationsDto = _mapper.Map<IEnumerable<Qualification>, IEnumerable<QualificationsDto>>(Qualifications);
            return Ok(qualificationsDto);
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

            var ExperiencesDto = _mapper.Map<IEnumerable<Experience>, IEnumerable<ExperiencesDto>>(Experiences);

            return Ok(ExperiencesDto);
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

            var RefereesDto = _mapper.Map<IEnumerable<Referee>, IEnumerable<RefereesDto>>(Referees);

            return Ok(RefereesDto);
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