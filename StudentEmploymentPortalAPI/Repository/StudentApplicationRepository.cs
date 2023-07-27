using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Repository
{
    public class StudentApplicationRepository
    {
        private readonly DataContext _context;
        public StudentApplicationRepository(DataContext context)
        {
            _context = context;
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
