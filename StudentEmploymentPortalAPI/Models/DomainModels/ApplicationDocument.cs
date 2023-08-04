using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Models.DomainModels
{
    public class ApplicationDocument
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public DateTime? UploadDate { get; set; }
        public string FilePath { get; set; }
        [ForeignKey(nameof(Application))]
       public Guid StudentApplicationId { get; set; }
        [ValidateNever]
        public StudentApplication Application { get; set; }
    }
}