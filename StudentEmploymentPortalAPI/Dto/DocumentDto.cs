using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Dto
{
    public class DocumentDto
    {
        public Guid JobPostId { get; set; }
        public List<IFormFile>? Files { get; set; } //List of files
        public List<string>? DocumentName { get; set; } //List of names of the files
    }
}
