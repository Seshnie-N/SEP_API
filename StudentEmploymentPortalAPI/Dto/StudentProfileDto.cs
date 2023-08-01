using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Dto
{
    public class StudentProfileDto
    {
        public Guid Id { get; set; }
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
        public Department? Department { set; get; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
    }
}
