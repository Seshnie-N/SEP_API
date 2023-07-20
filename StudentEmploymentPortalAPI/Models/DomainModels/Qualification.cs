using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        [ValidateNever]
        public Student Student { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QualificationTitle { get; set; }
        public string Subjects { get; set; }
        public string Majors { get; set; }
        public string SubMajors { get; set; }
        public string Research { get; set; }
    }
}
