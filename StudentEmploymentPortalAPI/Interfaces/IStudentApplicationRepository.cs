using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentApplicationRepository
    {
        bool CreateApplication(StudentApplication application);
        bool Save();
        ICollection<StudentApplication> GetApplications();
        ICollection<StudentApplication> GetApplications(string studentId);
        StudentApplication GetApplication(Guid applicationId);
        //StudentApplication GetCategory(int id);
    }
}
