using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmploymentPortalAPI.Dto
{
     public class LookupDataDto
    {
    public IEnumerable<Department> Departments { get; set; }
    public IEnumerable<DriversLicense> DriversLicenses { get; set; }
    public IEnumerable<Gender> Genders { get; set; }
    public IEnumerable<Race> Races { get; set; }
    public IEnumerable<Nationality> Nationalities { get; set; }
    public IEnumerable<YearOfStudy> YearsOfStudy { get; set; }
    }
    
}