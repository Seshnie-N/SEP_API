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
        public ICollection<StudentApplication> GetApplications(string studentId)
        {
            var applications = _context.Applications.Include(a => a.JobPost).Where(a => a.StudentId == studentId).ToList();
            return applications;
        }

        public StudentApplication GetApplication(Guid applicationId)
        {
            var application = _context.Applications.Include(a => a.JobPost).Include(a => a.Documents).Where(a => a.Id == applicationId).FirstOrDefault();
            return application;
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

    }
}
