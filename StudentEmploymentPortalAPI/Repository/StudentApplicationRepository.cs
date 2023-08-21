using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.Data.Entity;

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
            var applications = _context.Applications.Include(a => a.JobPost).ThenInclude(p => p.WeekHour)
                .Include(a => a.JobPost).ThenInclude(p => p.JobPostStatus)
                .Include(a => a.JobPost).ThenInclude(p => p.JobType)
                .Include(a => a.ApplicationStatus)
                .Where(a => a.StudentId == studentId).ToList();
            return applications;
        }

        public StudentApplication GetApplication(Guid applicationId)
        {
            var application = _context.Applications.Include(a => a.JobPost).ThenInclude(p => p.WeekHour)
                .Include(a => a.JobPost).ThenInclude(p => p.JobPostStatus)
                .Include(a => a.JobPost).ThenInclude(p => p.JobType)
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Documents)
                .Where(a => a.Id == applicationId).FirstOrDefault();
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

        public bool AddDocument(ApplicationDocument document)
        {
            _context.Add(document);
            return Save();
        }
    }
}
