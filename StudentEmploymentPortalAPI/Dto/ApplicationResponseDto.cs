using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Dto
{
    public class ApplicationResponseDto 
    {
        public Guid Id { get; set; }
        public string ApplicationStatus { get; set; }
        public JobPostDto JobPost { get; set; }
    }
}
