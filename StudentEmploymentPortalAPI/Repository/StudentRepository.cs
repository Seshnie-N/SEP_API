
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public Student GetStudentById(Guid id)
        {
            return _context.Students.Include(s => s.DriversLicense)
                .Include(s => s.Gender)
                .Include(s => s.Race)
                .Include(s => s.Nationality)
                .Include(s => s.YearOfStudy)
                .Include(s => s.Department)
                .FirstOrDefault(s => s.Id == id);
        }



        public void UpdateStudent(Guid studentId, Student updatedStudent)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            // Update student properties here
            student.Address = updatedStudent.Address;
            student.IdNumber = updatedStudent.IdNumber;
            student.DriversLicenseId = updatedStudent.DriversLicenseId;
            student.CareerObjective = updatedStudent.CareerObjective;
            student.GenderId = updatedStudent.GenderId;
            student.RaceId = updatedStudent.RaceId;
            student.NationalityId = updatedStudent.NationalityId;
            student.YearOfStudyId = updatedStudent.YearOfStudyId;
            student.DepartmentId = updatedStudent.DepartmentId;
            student.Skills = updatedStudent.Skills;
            student.Achivements = updatedStudent.Achivements;
            student.Interests = updatedStudent.Interests;

            _context.Students.Update(student);
            _context.SaveChanges();
        }



        public ICollection<Student> GetStudents()
        {
            return _context.Students.Include("DriversLicense")
                .Include(s => s.Gender)
                .Include(s => s.Race)
                .Include(s => s.Nationality)
                .Include(s => s.YearOfStudy)
                .Include(s => s.Department)
                .Include(s => s.Department.Faculty)
                .ToList();
        }

        public void AddReferee(Guid studentId,Referee referee)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null) {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }
            referee.StudentId = studentId;
            _context.Referees.Add(referee);
            _context.SaveChanges();
        }
        //Updating the Referee for a particular student
        public void UpdateReferee(Guid studentId, int Id, Referee updatedReferee)
        {
            var referee = _context.Referees.SingleOrDefault(r => r.StudentId == studentId && r.Id == Id);
            if (referee == null)
            {
                throw new ArgumentException($"Referee with ID {Id} not found for Student with ID {studentId}.");
            }

            // Update referee properties here
            referee.Name = updatedReferee.Name;
            referee.JobTitle = updatedReferee.JobTitle;
            referee.Insitution = updatedReferee.Insitution;
            referee.Cell = updatedReferee.Cell;
            referee.Email = updatedReferee.Email;

            _context.Referees.Update(referee);
            _context.SaveChanges();
        }



        public void AddQualification(Guid studentId, Qualification qualification)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            qualification.StudentId = studentId;
            _context.Qualifications.Add(qualification);
            _context.SaveChanges();
        }

        public void UpdateQualification(Guid studentId, int Id, Qualification updatedQualification)
        {
            var qualification = _context.Qualifications.SingleOrDefault(q => q.StudentId == studentId && q.Id == Id);
            if (qualification == null)
            {
                throw new ArgumentException($"Qualification with ID {Id} not found for Student with ID {studentId}.");
            }

            // Update qualification properties here
            qualification.Institution = updatedQualification.Institution;
            qualification.StartDate = updatedQualification.StartDate;
            qualification.EndDate = updatedQualification.EndDate;
            qualification.QualificationTitle = updatedQualification.QualificationTitle;
            qualification.Subjects = updatedQualification.Subjects;
            qualification.Majors = updatedQualification.Majors;
            qualification.SubMajors = updatedQualification.SubMajors;
            qualification.Research = updatedQualification.Research;

            _context.Qualifications.Update(qualification);
            _context.SaveChanges();
        }



        public void AddExperience(Guid studentId, Experience experience)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            experience.StudentId = studentId;
            _context.Experiences.Add(experience);
            _context.SaveChanges();
        }

        public void UpdateExperience(Guid studentId, int Id, Experience updatedExperience)
        {
            var experience = _context.Experiences.SingleOrDefault(e => e.StudentId == studentId && e.Id == Id);
            if (experience == null)
            {
                throw new ArgumentException($"Experience with ID {Id} not found for Student with ID {studentId}.");
            }

            // Update experience properties here
            experience.EmployerName = updatedExperience.EmployerName;
            experience.StartDate = updatedExperience.StartDate;
            experience.EndDate = updatedExperience.EndDate;
            experience.JobTitle = updatedExperience.JobTitle;
            experience.TasksAndResponsibilities = updatedExperience.TasksAndResponsibilities;

            _context.Experiences.Update(experience);
            _context.SaveChanges();
        }





        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
