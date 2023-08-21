using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Dto
{
    public class CompleteApplicationResponseDto 
    {
        public Guid Id { get; set; }
        public string ApplicationStatus { get; set; }
        public JobPostDto JobPost { get; set; }
        public ICollection<DocumentDto> Documents { get; set; }
    }
}
