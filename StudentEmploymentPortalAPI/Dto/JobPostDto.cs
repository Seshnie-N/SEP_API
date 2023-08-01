using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using StudentEmploymentPortalAPI.Models;

namespace StudentEmploymentPortalAPI.Dto
{
    public class JobPostDto
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string JobDescription { get; set; }
        public string KeyResponsibilities { get; set; }
        public string JobType { get; set; }
        public string WeekHour { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ClosingDate { get; set; }
        [Precision(18, 2)]
        public decimal HourlyRate { get; set; }
        public string MinimumRequirements { get; set; }
        public string ApplicationInstruction { get; set; }
       
    }
}
