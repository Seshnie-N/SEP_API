using Microsoft.EntityFrameworkCore;

using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
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
        //Post Methods
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
        }
        public void UpdateStudent(Guid studentId, Student updatedStudent)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.UserId == studentId.ToString());
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            // Update student properties here
            student.Address = updatedStudent.Address;
            student.IdNumber = updatedStudent.IdNumber;
            student.DriversLicenseId = updatedStudent.DriversLicenseId;
            student.CareerObjective = updatedStudent.CareerObjective;
            student.GenderId = updatedStudent.GenderId;
            student.RaceId = updatedStudent.RaceId;
            student.NationalityId = updatedStudent.NationalityId;
            student.YearOfStudyId = updatedStudent.YearOfStudyId;
            student.DepartmentId = updatedStudent.DepartmentId;
            student.Skills = updatedStudent.Skills;
            student.Achivements = updatedStudent.Achivements;
            student.Interests = updatedStudent.Interests;

            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
        }
        public void AddReferee(Guid studentId, Referee referee)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.UserId == studentId.ToString());
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }
            referee.StudentId = studentId.ToString();
            _dbContext.Referees.Add(referee);
            _dbContext.SaveChanges();
        }
        //Updating the Referee for a particular student
        public void UpdateReferee(Guid studentId, int Id, Referee updatedReferee)
        {
            var referee = _dbContext.Referees.SingleOrDefault(r => r.StudentId == studentId.ToString() && r.Id == Id);
            if (referee == null)
            {
                throw new ArgumentException($"Referee with ID {Id} not found for Student with ID {studentId}.");
            }

            // Update referee properties here
            referee.Name = updatedReferee.Name;
            referee.JobTitle = updatedReferee.JobTitle;
            referee.Insitution = updatedReferee.Insitution;
            referee.Cell = updatedReferee.Cell;
            referee.Email = updatedReferee.Email;

            _dbContext.Referees.Update(referee);
            _dbContext.SaveChanges();
        }



        public void AddQualification(Guid studentId, Qualification qualification)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.UserId == studentId.ToString());
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            qualification.StudentId = studentId.ToString();
            _dbContext.Qualifications.Add(qualification);
            _dbContext.SaveChanges();
        }

        public void UpdateQualification(Guid studentId, int Id, Qualification updatedQualification)
        {
            var qualification = _dbContext.Qualifications.SingleOrDefault(q => q.StudentId == studentId.ToString() && q.Id == Id);
            if (qualification == null)
            {
                throw new ArgumentException($"Qualification with ID {Id} not found for Student with ID {studentId}.");
            }

            // Update qualification properties here
            qualification.Institution = updatedQualification.Institution;
            qualification.StartDate = updatedQualification.StartDate;
            qualification.EndDate = updatedQualification.EndDate;
            qualification.QualificationTitle = updatedQualification.QualificationTitle;
            qualification.Subjects = updatedQualification.Subjects;
            qualification.Majors = updatedQualification.Majors;
            qualification.SubMajors = updatedQualification.SubMajors;
            qualification.Research = updatedQualification.Research;

            _dbContext.Qualifications.Update(qualification);
            _dbContext.SaveChanges();
        }



        public void AddExperience(Guid studentId, Experience experience)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.UserId == studentId.ToString());
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            experience.StudentId = studentId.ToString();
            _dbContext.Experiences.Add(experience);
            _dbContext.SaveChanges();
        }

        public void UpdateExperience(Guid studentId, int Id, Experience updatedExperience)
        {
            var experience = _dbContext.Experiences.SingleOrDefault(e => e.StudentId == studentId.ToString() && e.Id == Id);
            if (experience == null)
            {
                throw new ArgumentException($"Experience with ID {Id} not found for Student with ID {studentId}.");
            }

            // Update experience properties here
            experience.EmployerName = updatedExperience.EmployerName;
            experience.StartDate = updatedExperience.StartDate;
            experience.EndDate = updatedExperience.EndDate;
            experience.JobTitle = updatedExperience.JobTitle;
            experience.TasksAndResponsibilities = updatedExperience.TasksAndResponsibilities;

            _dbContext.Experiences.Update(experience);
            _dbContext.SaveChanges();
        }





        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        //Get methods
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
