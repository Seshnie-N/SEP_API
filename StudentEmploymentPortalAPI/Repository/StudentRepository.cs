
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
