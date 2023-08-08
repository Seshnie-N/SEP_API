using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
//Students
        void AddStudent(Student student);
        void UpdateStudent(Student updatedStudent);
        Student GetStudentProfile(Guid StudentId);
        Student GetCV(Guid StudentId);
        
//Qualifications
        void AddQualification(Qualification qualification);
        void UpdateQualification(Qualification updatedQualification);
         IList<Qualification> GetQualifications(Guid StudentId);
         Qualification GetQualification(int QualificationId);
        void WithdrawQualification(int QualificationId);

//Experiences
        void AddExperience(Experience experience);
        void UpdateExperience(Experience updatedExperience);
        IList<Experience> GetExperiences(Guid StudentId);
        Experience GetExperience(int ExperienceId);
        void WithdrawExperience(int ExperienceId);

//Referee
        void AddReferee(Referee referee);
        void UpdateReferee(Referee referee);
         IList<Referee> GetReferees(Guid StudentId);
        Referee GetReferee(int RefereeId);
        void WithdrawReferee(int RefereeId);

        //Save
        void Save();
    }
}
