
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





        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
