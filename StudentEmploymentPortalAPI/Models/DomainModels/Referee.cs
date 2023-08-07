using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentEmploymentPortalAPI.Models
{
    public class Referee
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        // [ValidateNever]
        // public Student Student { get; set; }
        [Required(ErrorMessage = "Please provide a name for the referee.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a job title for the referee.")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Please provide an institution for the referee.")]
        public string Insitution { get; set; }
        [RegularExpression("^(\\+27|0)[6-8][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        [Required(ErrorMessage = "Please provide a cell number for the referee.")]
        public string Cell { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Please provide an email address for the referee.")]
        public string Email { get; set; }

         public bool? IsAvailable { get; set; }

         public Referee()
        {
           
            IsAvailable = true; 
    }
    }
}
