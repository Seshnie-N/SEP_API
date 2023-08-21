using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
        void Create(string userId, RegisterDto user);
        Student GetStudent(string userId);
    }
}
