using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.Text.Json.Serialization;

namespace StudentEmploymentPortalAPI.Dto
{
    public class CVApplicationUserDto
    {
        //public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class CVDepartmentDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public FacultyDto Faculty { get; set; }
    }

    public class DriversLicenseDto
    {
        public string Type { get; set; }
    }

    public class GenderDto
    {
        public string Name { get; set; }
    }

    public class RaceDto
    {
        public string Name { get; set; }
    }

    public class NationalityDto
    {
        public string Name { get; set; }
    }

    public class YearOfStudyDto
    {
        public string Name { get; set; }
    }
    public class FacultyDto
    {
        public string Name { get; set; }
    }
    public class StudentCVDto
    {
        public CVApplicationUserDto User { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
        [ValidateNever]
        public DriversLicenseDto? DriversLicense { set; get; }
        public string? CareerObjective { set; get; }
        [ValidateNever]
        public GenderDto? Gender { set; get; }
        [ValidateNever]
        public RaceDto? Race { set; get; }
        [ValidateNever]
        public NationalityDto? Nationality { set; get; }
        [ValidateNever]
        public YearOfStudyDto? YearOfStudy { set; get; }
        [ValidateNever]
        public CVDepartmentDto? Department { set; get; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
        public ICollection<CVExperiencesDto> Experiences { set; get; }
        public ICollection<CVQualificationsDto> Qualifications { set; get; }
        public ICollection<CVRefereesDto> Referees { set; get; }
       
    }
}
