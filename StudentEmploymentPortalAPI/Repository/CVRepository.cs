using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Repository
{
    public class CVRepository : ICVRepository
    {
        private readonly DataContext _dbContext;

        public CVRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetStudent(Guid StudentId)
        {
            var Student = _dbContext.Students.Where(x => x.Id == StudentId).FirstOrDefault();

            if (Student == null)
                return null;

            return Student;
        }

        public Qualification GetQualification(int QualificationId)
        {
            var Qualification = _dbContext.Qualifications.Where(x => x.Id == QualificationId).FirstOrDefault();

            if (Qualification == null)
                return null;

            return Qualification;
        }

        public Experience GetExperience(int ExperienceId)
        {
            var Experience = _dbContext.Experiences.Where(x => x.Id == ExperienceId).FirstOrDefault();

            if (Experience == null)
                return null;

            return Experience;
        }

        public Referee GetReferee(int RefereeId)
        {
            var Referee = _dbContext.Referees.Where(x => x.Id == RefereeId).FirstOrDefault();

            if (Referee == null)
                return null;

            return Referee;
        }

        public IList<Qualification> GetQualifications(Guid StudentId)
        {

            var Qualifications = _dbContext.Qualifications
        .Where(q => q.StudentId == StudentId)
        .ToList();

            if (Qualifications == null)
                return null;

            return Qualifications;
        }

        public IList<Experience> GetExperiences(Guid StudentId)
        {
            var Experiences = _dbContext.Experiences
        .Where(e => e.StudentId == StudentId)
        .ToList();

            if (Experiences == null)
                return null;

            return Experiences;
        }

        public IList<Referee> GetReferees(Guid StudentId)
        {
            var Referees = _dbContext.Referees
        .Where(r => r.StudentId == StudentId)
        .ToList();

            if (Referees == null)
                return null;

            return Referees;
        }
    }
}
