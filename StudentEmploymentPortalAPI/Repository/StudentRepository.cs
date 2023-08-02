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
