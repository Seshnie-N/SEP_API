using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Dto;
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

        public LookupDataDto GetLookupData()
        {
            var departments = _context.Departments.Include(d => d.Faculty).ToList();
            var driversLicenses = _context.DriversLicenses.ToList();
            var genders = _context.Genders.ToList();
            var races = _context.Races.ToList();
            var nationalities = _context.Nationalities.ToList();
            var yearOfStudys = _context.YearOfStudy.ToList();

             var lookupData = new LookupDataDto
             {
                 Departments= departments,
                 DriversLicenses = driversLicenses,
                 Genders =genders,
                 Races = races,
                 Nationalities = nationalities,
                 YearsOfStudy = yearOfStudys
             };

            // IEnumerable<object> LookupData = Department.Cast<object>()
            // .Concat(DriversLicense)
            // .Concat(Gender)
            // .Concat(Race)
            // .Concat(Nationality)
            // .Concat(YearOfStudy);

        return lookupData;
        }
    }
}
