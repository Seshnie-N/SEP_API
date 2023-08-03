using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface ILookupRepository
    {
        IEnumerable<Faculty> GetFaculties();
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartmentWithFaculty();
        IEnumerable<YearOfStudy> GetYearOfStudy();
        IEnumerable<Gender> GetGender();
        IEnumerable<Race> GetRace();
        IEnumerable<DriversLicense> GetDriversLicense();

        //Endpoint to fetch all lookups for student profile
        //Race
        //Nationality
        //Gender
        //YearOfStudy
        //DriversLicense
    }
}
