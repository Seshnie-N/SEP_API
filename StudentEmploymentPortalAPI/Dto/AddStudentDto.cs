using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models.DomainModels;
using StudentEmploymentPortalAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentEmploymentPortalAPI.Dto
{
    public class AddStudentDto
    {
        public string UserId { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
        public int DriversLicenseId { get; set; }
        public DriversLicense? DriversLicense { set; get; }
        public string? CareerObjective { set; get; }
        public int GenderId { get; set; }
        
        public Gender? Gender { set; get; }
        public int RaceId { get; set; }
        public Race? Race { set; get; }
        public bool IsSouthAfrican { get; set; }
        public int NationalityId { get; set; }
        public Nationality? Nationality { set; get; }
        public int YearOfStudyId { get; set; }
        public YearOfStudy? YearOfStudy { set; get; }
        public int DepartmentId { get; set; }
       
        public Department? Department { set; get; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }

    }
}
