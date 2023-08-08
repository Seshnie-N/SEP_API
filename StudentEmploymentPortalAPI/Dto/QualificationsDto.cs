using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Dto
{
     public class AddQualificationDto
    {
       
        public string StudentId { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QualificationTitle { get; set; }
        public string? Subjects { get; set; }
        public string? Majors { get; set; }
        public string? SubMajors { get; set; }
        public string? Research { get; set; }

    }
     public class QualificationDto
    {
        
        public int Id { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QualificationTitle { get; set; }
        public string? Subjects { get; set; }
        public string? Majors { get; set; }
        public string? SubMajors { get; set; }
        public string? Research { get; set; }
    }
    public class QualificationsDto
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QualificationTitle { get; set; }
    }
    public class CVQualificationsDto
    {
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QualificationTitle { get; set; }
        public string? Subjects { get; set; }
        public string? Majors { get; set; }
        public string? SubMajors { get; set; }
        public string? Research { get; set; }
    }
}
