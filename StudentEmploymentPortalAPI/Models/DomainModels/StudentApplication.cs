using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class StudentApplication
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        [ValidateNever]
        public Student Student { get; set; }
        [ForeignKey(nameof(JobPost))]
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