using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface ICVRepository
    {
        
        Student GetStudentProfile(Guid StudentId);
        Student GetCV(Guid StudentId);
        Qualification GetQualification(int QualificationId);
        Experience GetExperience(int ExperienceId);
        Referee GetReferee(int RefereeId);


        //Lists
        IList<Qualification> GetQualifications(Guid StudentId);
        IList<Experience> GetExperiences(Guid StudentId);
        IList<Referee> GetReferees(Guid StudentId);

        //Create
        void AddStudent(Student student);
        void UpdateStudent(Guid studentId, Student updatedStudent);
       
        void AddReferee(Guid studentId, Referee referee);
        void UpdateReferee(Guid studentId, int Id, Referee referee);

        void AddQualification(Guid studentId, Qualification qualification);
        void UpdateQualification(Guid studentId, int Id, Qualification updatedQualification);

        void AddExperience(Guid studentId, Experience experience);
        void UpdateExperience(Guid studentId, int Id, Experience updatedExperience);

        void SaveChanges();
    }
}
