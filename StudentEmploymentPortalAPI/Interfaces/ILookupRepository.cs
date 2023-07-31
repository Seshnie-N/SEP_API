using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface ILookupRepository
    {
        IEnumerable<Faculty> GetFaculties();
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartmentWithFaculty();
    }
}
