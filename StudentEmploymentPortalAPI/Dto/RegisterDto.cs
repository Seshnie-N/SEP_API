using System.ComponentModel.DataAnnotations;

namespace StudentEmploymentPortalAPI.Dto
{
    public class RegisterDto : LoginDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
    }
}