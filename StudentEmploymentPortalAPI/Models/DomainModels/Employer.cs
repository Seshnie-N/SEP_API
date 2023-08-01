using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class Employer
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string RegisteredBusinessName { get; set; }
        public string TradingName { get; set; }
        public string RegisteredAddress { get; set; }
        public int BusinessTypeId { get; set; }
        [ValidateNever]
        public BusinessType BusinessType { get; set; }
        public int EmployerStatusId { get; set; }
        [ValidateNever]
        public EmployerStatus EmployerStatus { get; set; }
        public int EmployerTypeId { get; set; }
        [ValidateNever]
        public EmployerType EmployerType { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
