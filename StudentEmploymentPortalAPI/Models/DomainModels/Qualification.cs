using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        [ValidateNever]
        public Student Student { get; set; }
        [Required(ErrorMessage = "Enter the name of the institution at which the qualification was obtained.")]
        public string Institution { get; set; }
        [Required(ErrorMessage = "Please provide a valid start date.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please provide a valid end date.")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please provide the title of your qualification.")]
        public string QualificationTitle { get; set; }
        public string? Subjects { get; set; }
        public string? Majors { get; set; }
        public string? SubMajors { get; set; }
        public string? Research { get; set; }
    }
}
