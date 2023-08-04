using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentApplicationRepository
    {
        bool CreateApplication(StudentApplication application);
        bool Save();
        ICollection<StudentApplication> GetApplications();
        bool AddDocument(ApplicationDocument document);
        //StudentApplication GetCategory(int id);
    }
}
