using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudentById(Guid id);

        void AddStudent(Student student);
        void SaveChanges();
    }
}