using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class StudentApplication
    {
        public int Id { get; set; }
        [ValidateNever]
        public Guid StudentId { get; set; }

        public int JobPostId { get; set; }
        [ValidateNever]
        public JobPost JobPost { get; set; }

        public int? ApplicationStatusId { get; set; }
        [ValidateNever]
        public ApplicationStatus? ApplicationStatus { get; set; }
        [ValidateNever]
        public ICollection<ApplicationDocument> Documents { get; set; }
    }
}