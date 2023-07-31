using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudentById(Guid id);

        void AddStudent(Student student);
        void SaveChanges();
        void AddReferee(Guid studentId, Referee referee);
        void AddQualification(Guid studentId, Qualification qualification);
        void AddExperience(Guid studentId, Experience experience);
    }
}