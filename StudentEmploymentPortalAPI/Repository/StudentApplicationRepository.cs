using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Repository
{
    public class StudentApplicationRepository : IStudentApplicationRepository
    {
        private readonly DataContext _context;
        public StudentApplicationRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<StudentApplication> GetApplications()
        {
            return _context.Applications.ToList();
        }
        public bool CreateApplication(StudentApplication application)
        {
            _context.Add(application);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool AddDocument(ApplicationDocument document)
        {
            _context.Add(document);
            return Save();
        }
    }
}
