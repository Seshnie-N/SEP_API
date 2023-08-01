using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudentById(Guid id);

        void AddStudent(Student student);
        void UpdateStudent(Guid studentId, Student updatedStudent);
        void SaveChanges();
        void AddReferee(Guid studentId, Referee referee);
        void UpdateReferee(Guid studentId,int Id,Referee referee);
        void AddQualification(Guid studentId, Qualification qualification);
        void UpdateQualification(Guid studentId, int Id, Qualification updatedQualification);

        void AddExperience(Guid studentId, Experience experience);
        void UpdateExperience(Guid studentId, int Id, Experience updatedExperience);

    }
}