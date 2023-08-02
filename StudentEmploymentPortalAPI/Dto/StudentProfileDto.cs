using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Dto
{
    public class ApplicationUserDto
    {
         public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class DepartmentDto
    {
         public int DepartmentId { get; set; }
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
    }

    public class StudentProfileDto
    {
        //public Guid Id { get; set; }
        public  ApplicationUserDto User { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
        [ValidateNever]
        public DriversLicense? DriversLicense { set; get; }
        public string? CareerObjective { set; get; }
        [ValidateNever]
        public Gender? Gender { set; get; }
        [ValidateNever]
        public Race? Race { set; get; }
        [ValidateNever]
        public Nationality? Nationality { set; get; }
        [ValidateNever]
        public YearOfStudy? YearOfStudy { set; get; }
        [ValidateNever]
        public DepartmentDto? Department { set; get; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
    }
}
