using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentEmploymentPortalAPI.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        [ValidateNever]
      //  public Student Student { get; set; }
        public string EmployerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string TasksAndResponsibilities { get; set; }
    }
}
