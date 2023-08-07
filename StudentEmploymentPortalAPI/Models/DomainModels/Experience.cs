using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentEmploymentPortalAPI.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        // [ValidateNever]
        // public Student Student { get; set; }
        [Required(ErrorMessage = "Please provide an employer name.")]
        public string EmployerName { get; set; }
        [Required(ErrorMessage = "Please provide a valid start date.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please provide a valid end date.")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please provide a job title.")]
        public string JobTitle { get; set; }
        public string TasksAndResponsibilities { get; set; }
        public bool? IsAvailable { get; set; }

         public Experience()
        {
           
            IsAvailable = true; 
    }
    }
}
