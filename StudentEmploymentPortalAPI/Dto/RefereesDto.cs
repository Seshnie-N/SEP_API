using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentEmploymentPortalAPI.Dto
{
     public class AddRefereeDto
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Insitution { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
    }
     public class RefereeDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Insitution { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        
    }

    public class RefereesDto
    {
        public int Id { get; set; }
        public string Insitution { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        
    }

    public class CVRefereesDto
    {
       
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Insitution { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }

    }
}
