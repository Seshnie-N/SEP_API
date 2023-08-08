using Microsoft.EntityFrameworkCore;

using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Dto;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;

namespace StudentEmploymentPortalAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dbContext;
        
//Constructor
        public StudentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

//Students
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            Save();
        }
        public void UpdateStudent(Student updatedStudent)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.UserId == updatedStudent.UserId.ToString());
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {updatedStudent.UserId} not found.");
            }

            // Update student properties
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
            Save();
        }

       public Student GetStudentProfile(Guid studentId)
        {
            var student = _dbContext.Students
                          .Include(p => p.User)
                        //  .Include(p => p.DriversLicense)
                        //  .Include(p => p.Gender)
                        //  .Include(p => p.Race)
                        //  .Include(p => p.Nationality)
                        //  .Include(p => p.YearOfStudy)
                        //  .Include(p => p.Department)
                        //  .Include(p => p.Department.Faculty)
                         .SingleOrDefault(x => x.UserId == studentId.ToString());

            return student;
        }

         public Student GetCV(Guid studentId)
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
                        .Include(p => p.Qualifications)
                        .Include(p => p.Experiences)
                        .Include(p => p.Referees)
                        .SingleOrDefault(x => x.UserId == studentId.ToString());

            return student;
        }

//Qualifications
        public void AddQualification(Qualification qualification)
          {
            
            _dbContext.Qualifications.Add(qualification);
            Save();
          }

        public void UpdateQualification(Qualification updatedQualification)
        {
            var qualification = _dbContext.Qualifications.SingleOrDefault(q => q.Id == updatedQualification.Id);
            if (qualification == null)
            {
                throw new ArgumentException($"Qualification with ID {updatedQualification.Id} not found.");
            }

            // Update qualification properties
            qualification.Institution = updatedQualification.Institution;
            qualification.StartDate = updatedQualification.StartDate;
            qualification.EndDate = updatedQualification.EndDate;
            qualification.QualificationTitle = updatedQualification.QualificationTitle;
            qualification.Subjects = updatedQualification.Subjects;
            qualification.Majors = updatedQualification.Majors;
            qualification.SubMajors = updatedQualification.SubMajors;
            qualification.Research = updatedQualification.Research;

            _dbContext.Qualifications.Update(qualification);
            Save();
        }

       public IList<Qualification> GetQualifications(Guid studentId)
        {
           var qualifications = _dbContext.Qualifications
                                .Where(x => x.StudentId == studentId.ToString() && x.IsAvailable == true)
                                .ToList();

            return qualifications;
        }

          public Qualification GetQualification(int qualificationId)
        {
            var qualification = _dbContext.Qualifications.FirstOrDefault(x => x.Id == qualificationId);
            return qualification;
        }

       
          public void WithdrawQualification(int QualificationId)
        {
           var qualification = _dbContext.Qualifications.SingleOrDefault(q => q.Id == QualificationId );
            if (qualification == null)
            {
                throw new ArgumentException($"Qualification with ID {QualificationId} not found.");
            }

            // Update qualification properties
            qualification.IsAvailable = false;
            

            _dbContext.Qualifications.Update(qualification);
            _dbContext.SaveChanges();
                
        }

//Experiences
        public void AddExperience(Experience experience)
        {
            _dbContext.Experiences.Add(experience);
            Save();
        }

        public void UpdateExperience(Experience updatedExperience)
        {
            var experience = _dbContext.Experiences.SingleOrDefault(e => e.Id == updatedExperience.Id);
            if (experience == null)
            {
                throw new ArgumentException($"Experience with ID {updatedExperience.Id} not found.");
            }

            // Update experience properties
            experience.EmployerName = updatedExperience.EmployerName;
            experience.StartDate = updatedExperience.StartDate;
            experience.EndDate = updatedExperience.EndDate;
            experience.JobTitle = updatedExperience.JobTitle;
            experience.TasksAndResponsibilities = updatedExperience.TasksAndResponsibilities;

            _dbContext.Experiences.Update(experience);
           Save();
        }

      public IList<Experience> GetExperiences(Guid studentId)
        {
            var experiences = _dbContext.Experiences
                                .Where(x => x.StudentId == studentId.ToString() && x.IsAvailable == true)
                                .ToList();
            return experiences;
        }

         public Experience GetExperience(int experienceId)
        {
            var experience = _dbContext.Experiences.FirstOrDefault(x => x.Id == experienceId);
            return experience;
        }

         public void WithdrawExperience(int ExperienceId)
        {
             var Experience = _dbContext.Experiences.SingleOrDefault(q => q.Id == ExperienceId );
            if (Experience == null)
            {
                throw new ArgumentException($"Experience with ID {ExperienceId} not found.");
            }

            Experience.IsAvailable = false;
            
            _dbContext.Experiences.Update(Experience);
            _dbContext.SaveChanges();
        }
//Referees
        public void AddReferee(Referee referee)
        {
             _dbContext.Referees.Add(referee);
            Save();
        }
        
        public void UpdateReferee(Referee updatedReferee)
        {
            var referee = _dbContext.Referees.SingleOrDefault(r => r.Id == updatedReferee.Id);
            if (referee == null)
            {
                throw new ArgumentException($"Referee with ID {updatedReferee.Id} not found.");
            }

            // Update referee properties
            referee.Name = updatedReferee.Name;
            referee.JobTitle = updatedReferee.JobTitle;
            referee.Insitution = updatedReferee.Insitution;
            referee.Cell = updatedReferee.Cell;
            referee.Email = updatedReferee.Email;

            _dbContext.Referees.Update(referee);
            Save();
        }

         public IList<Referee> GetReferees(Guid studentId)
        {
           var referees = _dbContext.Referees
                                .Where(x => x.StudentId == studentId.ToString() && x.IsAvailable == true)
                                .ToList();
            return referees;
        }

        public Referee GetReferee(int refereeId)
        {
            var referee = _dbContext.Referees.FirstOrDefault(x => x.Id == refereeId);
            return referee;
        }

         public void WithdrawReferee(int RefereeId)
        {
            var Referee = _dbContext.Referees.SingleOrDefault(q => q.Id == RefereeId );
            if (Referee == null)
            {
                throw new ArgumentException($"Referee with ID {RefereeId} not found.");
            }

            Referee.IsAvailable = false;
            
            _dbContext.Referees.Update(Referee);
            _dbContext.SaveChanges();
        }


        //Save
        public void Save()
        {
            _dbContext.SaveChanges();
        }
       
    }
}
