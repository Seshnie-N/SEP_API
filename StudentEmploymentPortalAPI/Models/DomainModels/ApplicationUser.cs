using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        [ValidateNever]
        public virtual Student Student { get; set; }
    }
}
