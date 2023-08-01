using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface ICVRepository
    {
        Student GetStudent(Guid StudentId);
        Qualification GetQualification(int QualificationId);
        Experience GetExperience(int ExperienceId);
        Referee GetReferee(int RefereeId);

        IList<Qualification> GetQualifications(Guid StudentId);
        IList<Experience> GetExperiences(Guid StudentId);
        IList<Referee> GetReferees(Guid StudentId);

    }
}
