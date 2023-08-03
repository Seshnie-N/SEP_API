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

        public IEnumerable<YearOfStudy> GetYearOfStudy()
        {
            return _context.YearOfStudy.ToList();
        }

        public IEnumerable<Gender> GetGender()
        {
            return _context.Genders.ToList();
        }

        public IEnumerable<Race> GetRace()
        {
            return _context.Races.ToList();
        }

        public IEnumerable<DriversLicense> GetDriversLicense()
        {
            return _context.DriversLicenses.ToList();
        }
    }
}
