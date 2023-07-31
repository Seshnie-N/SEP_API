using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudent(string userId);
        ICollection<Student> GetStudents();
    }
}
