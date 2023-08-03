using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    [Table("Students")]
    public class Student 
    {
        [Key, ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ValidateNever]
        public virtual ApplicationUser User { get; set; }
        public string? Address { set; get; }
        [Required(ErrorMessage = "Please enter your ID number")]
        [DisplayName("ID Number")]
        [RegularExpression("(([0-9]{2})(0|1)([0-9])([0-3])([0-9]))([ ]?)(([ 0-9]{4})([ ]?)([ 0-1][8]([ ]?)[ 0-9]))", ErrorMessage = "Invalid ID number")]
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
        public bool IsSouthAfrican { get; set; }
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
        public string? Achievements { set; get; }
        public string? Interests { set; get; }
        public ICollection<Experience>? Experiences { set; get; }
        public ICollection<Qualification>? Qualifications { set; get; }
        public ICollection<Referee>? Referees { set; get;}
        public ICollection<StudentApplication>? StudentApplications { set; get; }

    }
}
