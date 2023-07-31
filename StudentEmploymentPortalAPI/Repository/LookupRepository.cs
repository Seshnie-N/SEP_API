using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Repository
{
    public class LookupRepository : ILookupRepository
    {
        private readonly DataContext _context;

        public LookupRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return _context.Faculties.ToList();
        }

        public IEnumerable<Department> GetDepartmentWithFaculty()
        {
            return _context.Departments.Include(d => d.Faculty).ToList();
        }
    }
}
