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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IMapper _mapper;
     
//Constructor
        public StudentController(IStudentRepository StudentRepository, IMapper mapper)
        {
            _StudentRepository = StudentRepository;
            _mapper = mapper;

        }

 //Students

        [HttpPost("AddStudent")]
        [ProducesResponseType(201, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult AddStudent([FromBody] AddStudentDto addStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var student = _mapper.Map<Student>(addStudentDto);

            _StudentRepository.AddStudent(student);

             return Content("Student added successfully");
        }

        [HttpPut("UpdateStudent")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateStudent([FromBody] UpdateStudentProfileDto updateStudentProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var student = _mapper.Map<Student>(updateStudentProfileDto);

            _StudentRepository.UpdateStudent(student);

             return Content("Student updated successfully");
        }

        [HttpGet("Get Student CV")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetCV(Guid StudentId)
        {


            var Student = _StudentRepository.GetCV(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentCVDto = _mapper.Map<Student, StudentCVDto>(Student);

            return Ok(studentCVDto);
        }

        [HttpGet("Get Student profile")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudent(Guid StudentId)
        {


            var Student = _StudentRepository.GetStudentProfile(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentProfileDto = _mapper.Map<Student, StudentProfileDto>(Student);

            return Ok(studentProfileDto);
        }


//Qualifications

        [HttpPost("AddQualification")]
        [ProducesResponseType(201, Type = typeof(Qualification))]
        [ProducesResponseType(400)]
        public IActionResult AddQualification([FromBody] AddQualificationDto addQualificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var qualification = _mapper.Map<Qualification>(addQualificationDto);

            _StudentRepository.AddQualification(qualification);
            

             return Content("Qualification added successfully");
        }

        [HttpPut("UpdateQualification")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQualification([FromBody] QualificationDto qualificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var qualification = _mapper.Map<Qualification>(qualificationDto);

            _StudentRepository.UpdateQualification(qualification);
            

             return Content("Qualification updated successfully");
        }

        [HttpGet("Get Qualifications")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Qualification>))]
        public IActionResult GetQualifications(Guid StudentId)
        {
            var Qualifications = _StudentRepository.GetQualifications(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var qualificationsDto = _mapper.Map<IEnumerable<Qualification>, IEnumerable<QualificationsDto>>(Qualifications);
            return Ok(qualificationsDto);
        }

        [HttpGet("Get Qualification")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Qualification>))]
        public IActionResult GetQualification(int QualificationId)
        {
            var Qualification = _StudentRepository.GetQualification(QualificationId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
             var QualificationDto = _mapper.Map<Qualification, QualificationDto>(Qualification);
            return Ok(QualificationDto);
        }

        [HttpPut("WithdrawQualification/{qualificationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult WithdrawQualification(int qualificationId)
        {
            try
            {
                _StudentRepository.WithdrawQualification(qualificationId);
                return Content("Qualification withdrawn Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

//Experiences

        [HttpPost("AddExperience")]
        [ProducesResponseType(201, Type = typeof(Experience))]
        [ProducesResponseType(400)]
        public IActionResult AddExperience([FromBody] AddExperienceDto addExperienceDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var experience = _mapper.Map<Experience>(addExperienceDto);

            _StudentRepository.AddExperience(experience);
            

             return Content("Experience added successfully");
        }

        [HttpPut("UpdateExperience")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateExperience([FromBody] ExperienceDto experienceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var experience = _mapper.Map<Experience>(experienceDto);

            _StudentRepository.UpdateExperience(experience);
            

             return Content("Experience updated successfully");
        }

        [HttpGet("Get Experiences")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        public IActionResult GetExperiences(Guid StudentId)
        {
            var Experiences = _StudentRepository.GetExperiences(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ExperiencesDto = _mapper.Map<IEnumerable<Experience>, IEnumerable<ExperiencesDto>>(Experiences);

            return Ok(ExperiencesDto);
        }
        [HttpGet("Get Experience")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        public IActionResult GetExperience(int ExperienceId)
        {
            var Experience = _StudentRepository.GetExperience(ExperienceId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
             var ExperienceDto = _mapper.Map<Experience, ExperienceDto>(Experience);

            return Ok(ExperienceDto);
        }

        [HttpPut("WithdrawExperience/{ExperienceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult WithdrawExperience(int ExperienceId)
        {
            try
            {
                _StudentRepository.WithdrawExperience(ExperienceId);
                return Content("Experience Withdrawn Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

//Referees

        [HttpPost("AddReferee")]
        [ProducesResponseType(201, Type = typeof(Referee))]
        [ProducesResponseType(400)]
        public IActionResult AddReferee([FromBody] AddRefereeDto addRefereeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var referee = _mapper.Map<Referee>(addRefereeDto);

            _StudentRepository.AddReferee(referee);
            

             return Content("Referee added successfully");
        }

        [HttpPut("UpdateReferee")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateReferee([FromBody] RefereeDto refereeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var referee = _mapper.Map<Referee>(refereeDto);

            _StudentRepository.UpdateReferee(referee);
            

             return Content("Referee updated successfully");
        }

        [HttpGet("Get Referees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Referee>))]
        public IActionResult GetReferees(Guid StudentId)
        {
            var Referees = _StudentRepository.GetReferees(StudentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var RefereesDto = _mapper.Map<IEnumerable<Referee>, IEnumerable<RefereesDto>>(Referees);

            return Ok(RefereesDto);
        }

        [HttpGet("Get Referee")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Referee>))]
        public IActionResult GetReferee(int RefereeId)
        {
            var Referee = _StudentRepository.GetReferee(RefereeId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
             var RefereeDto = _mapper.Map<Referee, RefereeDto>(Referee);

            return Ok(RefereeDto);
        }

        [HttpPut("WithdrawReferee/{RefereeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult WithdrawReferee(int RefereeId)
        {
            try
            {
                _StudentRepository.WithdrawReferee(RefereeId);
                return Content("Referee Withdrawn Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}