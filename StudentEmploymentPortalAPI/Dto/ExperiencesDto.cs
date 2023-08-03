using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Dto
{
    public class ExperiencesDto
    {
        public int Id { get; set; }
        public string EmployerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
    }

    public class CVExperiencesDto
    {
        
        public string EmployerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string TasksAndResponsibilities { get; set; }
    }
}

