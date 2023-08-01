using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentEmploymentPortalAPI.Models
{
    public class Referee
    {
        public int Id { get; set; }
        [ValidateNever]
        public Guid StudentId { get; set; }

        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Insitution { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
    }
}
