using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
        public int DriversLicenseId { get; set; }
        [ValidateNever]
        public DriversLicense? DriversLicense { set; get; }
        public string? CareerObjective { set; get; }
        public int GenderId { get; set; }
        [ValidateNever]
        public Gender? Gender { set; get; }
        public int RaceId { get; set; }
        [ValidateNever]
        public Race? Race { set; get; }
        public int NationalityId { get; set; }
        [ValidateNever]
        public Nationality? Nationality { set; get; }
        public int YearOfStudyId { get; set; }
        [ValidateNever]
        public YearOfStudy? YearOfStudy { set; get; }
        public int DepartmentId { get; set; }
        [ValidateNever]
        public Department? Department { set; get; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
        public ICollection<Experience> Experiences { set; get; }
        public ICollection<Qualification> Qualifications { set; get; }
        public ICollection<Referee> Referees { set; get;}
        public ICollection<StudentApplication> StudentApplications { set; get; }

    }
}
