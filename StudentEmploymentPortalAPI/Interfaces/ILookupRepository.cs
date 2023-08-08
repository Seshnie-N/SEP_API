using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface ILookupRepository
    {
        IEnumerable<Faculty> GetFaculties();
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartmentWithFaculty();

        LookupDataDto GetLookupData();
        //Endpoint to fetch all lookups for student profile
        //Race
        //Nationality
        //Gender
        //YearOfStudy
        //DriversLicense
    }
}
