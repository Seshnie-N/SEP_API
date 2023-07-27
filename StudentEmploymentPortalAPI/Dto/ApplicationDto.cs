using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Dto
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public int JobPostId { get; set; }
        public int ApplicationStatusId { get; set; }
    }
}
