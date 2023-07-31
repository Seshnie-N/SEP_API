using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Interfaces;
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
    }
}
