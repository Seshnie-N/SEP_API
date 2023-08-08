using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.Text.Json.Serialization;

namespace StudentEmploymentPortalAPI.Dto
{

    //ApplicationUser

     public class ApplicationUserDto
    {
         public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class CVApplicationUserDto
    {
        //public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    

    //Student
    public class AddStudentDto
    {
      
        public string UserId { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
        public int DriversLicenseId { get; set; }
        public string? CareerObjective { set; get; }
        public int GenderId { get; set; }
        public int RaceId { get; set; }
        public bool IsSouthAfrican { get; set; }
        public int NationalityId { get; set; }
        public int YearOfStudyId { get; set; }
        public int DepartmentId { get; set; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
        
    }

     public class UpdateStudentProfileDto
    {
         public string UserId { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
         public int DriversLicenseId { get; set; }
        public string? CareerObjective { set; get; }
         public int GenderId { get; set; }
        public int RaceId { get; set; }
        public int NationalityId { get; set; }
        public int YearOfStudyId { get; set; }
         public int DepartmentId { get; set; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
    }
     public class StudentProfileDto
    {
        //public Guid Id { get; set; }
        public  ApplicationUserDto User { get; set; }
        public string? Address { set; get; }
        public string? IdNumber { set; get; }
        //[ValidateNever]
         public int DriversLicenseId { get; set; }
        //public DriversLicense? DriversLicense { set; get; }
        public string? CareerObjective { set; get; }
        //[ValidateNever]
         public int GenderId { get; set; }
        //public Gender? Gender { set; get; }
        //[ValidateNever]
        public int RaceId { get; set; }
        //public Race? Race { set; get; }
        //[ValidateNever]
        public int NationalityId { get; set; }
        //public Nationality? Nationality { set; get; }
        //[ValidateNever]
        public int YearOfStudyId { get; set; }
        //public YearOfStudy? YearOfStudy { set; get; }
        //[ValidateNever]
         public int DepartmentId { get; set; }
        //public DepartmentDto? Department { set; get; }
        public string? Skills { set; get; }
        public string? Achivements { set; get; }
        public string? Interests { set; get; }
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


    //Department

    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
    }
    public class CVDepartmentDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public FacultyDto Faculty { get; set; }
    }

    //DriversLicense
    public class DriversLicenseDto
    {
        public string Type { get; set; }
    }

    //Gender
    public class GenderDto
    {
        public string Name { get; set; }
    }
  
    //Race
    public class RaceDto
    {
        public string Name { get; set; }
    }

    //Nationality
    public class NationalityDto
    {
        public string Name { get; set; }
    }

    //YearOfStudy
    public class YearOfStudyDto
    {
        public string Name { get; set; }
    }

    //Faculty
    public class FacultyDto
    {
        public string Name { get; set; }
    }
   
}
