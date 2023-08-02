using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentEmploymentPortalAPI.Repository
{
    public class CVRepository : ICVRepository
    {
        private readonly DataContext _dbContext;

        public CVRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetStudent(Guid studentId)
        {
            var student = _dbContext.Students
                         .Include(p => p.User)
                         .Include(p => p.DriversLicense)
                         .Include(p => p.Gender)
                         .Include(p => p.Race)
                         .Include(p => p.Nationality)
                         .Include(p => p.YearOfStudy)
                         .Include(p => p.Department)
                         .Include(p => p.Department.Faculty)
                         .SingleOrDefault(x => x.UserId == studentId.ToString());

            return student;
        }

        public Qualification GetQualification(int qualificationId)
        {
            var qualification = _dbContext.Qualifications.FirstOrDefault(x => x.Id == qualificationId);
            return qualification;
        }

        public Experience GetExperience(int experienceId)
        {
            var experience = _dbContext.Experiences.FirstOrDefault(x => x.Id == experienceId);
            return experience;
        }

        public Referee GetReferee(int refereeId)
        {
            var referee = _dbContext.Referees.FirstOrDefault(x => x.Id == refereeId);
            return referee;
        }

        public IList<Qualification> GetQualifications(Guid studentId)
        {
            var qualifications = _dbContext.Qualifications.Where(x => x.StudentId == studentId.ToString()).ToList();
            return qualifications;
        }

        public IList<Experience> GetExperiences(Guid studentId)
        {
            var experiences = _dbContext.Experiences.Where(x => x.StudentId == studentId.ToString()).ToList();
            return experiences;
        }

        public IList<Referee> GetReferees(Guid studentId)
        {
            var referees = _dbContext.Referees.Where(x => x.StudentId == studentId.ToString()).ToList();
            return referees;
        }
    }
}
