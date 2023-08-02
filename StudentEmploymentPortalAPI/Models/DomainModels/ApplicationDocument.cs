using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class ApplicationDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FilePath { get; set; }
       public Guid StudentApplicationId { get; set; }
    }
}