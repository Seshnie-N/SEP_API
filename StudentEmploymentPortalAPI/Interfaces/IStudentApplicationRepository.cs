using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentApplicationRepository
    {
        bool CreateApplication(StudentApplication application);
        bool Save();
        ICollection<StudentApplication> GetApplications(string studentId);
        StudentApplication GetApplication(Guid applicationId);
        ICollection<StudentApplication> GetApplications();
        bool AddDocument(ApplicationDocument document);
        IQueryable<StudentApplication> GetApplicationsQueryable();
        //StudentApplication GetCategory(int id);
    }
}
