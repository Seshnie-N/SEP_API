using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // POST: api/Students/
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Here, you would perform any additional validation or business logic as needed.
            // For example, checking if the provided IdNumber or Email already exists, etc.

            // If everything is valid, add the student to the repository and save changes.
            _studentRepository.AddStudent(student);
            _studentRepository.SaveChanges();

            // Return the newly created student with a 201 Created status.
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // GET: api/Students/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(404)]
        public IActionResult GetById(Guid id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        // POST: api/Students/AddReferee/{studentId}
        [HttpPost("{studentId}/AddReferee")]
        [ProducesResponseType(201, Type = typeof(Referee))]
        [ProducesResponseType(400)]
        public IActionResult AddReferee(Guid studentId, Referee referee)
        {
            try
            {
                _studentRepository.AddReferee(studentId, referee);
                return CreatedAtAction(nameof(GetById), new { id = studentId }, referee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: api/Students/AddQualification/{studentId}
        [HttpPost("{studentId}/AddQualification")]
        [ProducesResponseType(201, Type = typeof(Qualification))]
        [ProducesResponseType(400)]
        public IActionResult AddQualification(Guid studentId, Qualification qualification)
        {
            try
            {
                _studentRepository.AddQualification(studentId, qualification);
                return CreatedAtAction(nameof(GetById), new { id = studentId }, qualification);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Students/AddExperience/{studentId}
        [HttpPost("{studentId}/AddExperience")]
        [ProducesResponseType(201, Type = typeof(Experience))]
        [ProducesResponseType(400)]
        public IActionResult AddExperience(Guid studentId, Experience experience)
        {
            try
            {
                _studentRepository.AddExperience(studentId, experience);
                return CreatedAtAction(nameof(GetById), new { id = studentId }, experience);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
