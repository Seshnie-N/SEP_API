using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json.Serialization;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class JobPost
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Guid EmployerId { get; set; }
        [ValidateNever]
        public Employer Employer { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string JobDescription { get; set; }
        public string KeyResponsibilities { get; set; }
        public int JobTypeId { get; set; }
        [ValidateNever]
        public JobType JobType { get; set; }
        public int WeekHourId { get; set; }
        [ValidateNever]
        public WeekHour WeekHour { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ClosingDate { get; set; }
        [Precision(18, 2)]
        public decimal HourlyRate { get; set; }
        public bool LimitedToSA { get; set; }
        public bool LimitedTo1stYear { get; set; }
        public bool LimitedTo2ndYear { get; set; }
        public bool LimitedTo3rdYear { get; set; }
        public bool LimitedToHonours { get; set; }
        public bool LimitedToGraduate { get; set; }
        public bool LimitedToMasters { get; set; }
        public bool LimitedToPhd { get; set; }
        public bool LimitedToPostdoc { get; set; }
        public bool LimitedToDepartment { get; set; }
        public bool LimitedToFaculty { get; set; }
        public string MinimumRequirements { get; set; }
        public string ApplicationInstruction { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string? ApproversComment { get; set; }
        public bool IsApproved { get; set; } 
        public int JobPostStatusId { get; set; }
        [ValidateNever]
        public JobPostStatus JobPostStatus { get; set; }
        public ICollection<StudentApplication> Applications { get; set; }
    }
}