using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Interfaces;
using StudentEmploymentPortalAPI.Models.DomainModels;
using StudentEmploymentPortalAPI.Dto;

namespace StudentEmploymentPortalAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(string userId, RegisterDto user)
        {
            bool isSA = _context.Nationalities.Where(n => n.Id == user.NationalityId).Select(n => n.Name).FirstOrDefault() == "South African";
            var student = new Student
            {
                UserId = userId,
                Address = user.Address,
                IdNumber = user.IdNumber,
                DriversLicenseId = user.DriversLicenseId,
                CareerObjective = user.CareerObjective,
                GenderId = user.GenderId,
                RaceId = user.RaceId,
                NationalityId = user.NationalityId,
                IsSouthAfrican = isSA,
                YearOfStudyId = user.YearOfStudyId,
                DepartmentId = user.DepartmentId,
                Skills = user.Skills,
                Achievements = user.Achievements,
                Interests = user.Interests
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public ICollection<Student> GetStudents()
        {
            return _context.Students.Include("DriversLicense")
                .Include("Gender")
                .Include("Race")
                .Include("Nationality")
                .Include("YearOfStudy")
                .Include("Department")
                .ToList();
        }

        public Student GetStudent(string userId)
        {
            return _context.Students.Where(s => s.UserId == userId).Include("DriversLicense")
                .Include("Gender")
                .Include("Race")
                .Include("Nationality")
                .Include("YearOfStudy")
                .Include("Department")
                .FirstOrDefault();
        }
    }
}
