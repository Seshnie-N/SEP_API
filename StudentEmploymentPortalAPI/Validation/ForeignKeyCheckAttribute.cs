using StudentEmploymentPortalAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace StudentEmploymentPortalAPI.Validation
{
    public class ForeignKeyCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value == 0)
            {
                return new ValidationResult("Invalid Id"); 
            }

            if (value is int id && id > 0) 
            {
                var dbContext = (DataContext)validationContext.GetService(typeof(DataContext));
                var table = validationContext.DisplayName;
                
                switch (table)
                {
                    case "DriversLicence":
                       if (dbContext.DriversLicenses.Find(id) == null)
                            return new ValidationResult("Invalid DriversLicenseId");
                        break;
                    case "Gender":
                        if (dbContext.Genders.Find(id) == null)
                            return new ValidationResult("Invalid GenderId");
                        break;
                    case "Race":
                        if (dbContext.Races.Find(id) == null)
                            return new ValidationResult("Invalid RaceId");
                        break;
                    case "Nationality":
                        if (dbContext.Nationalities.Find(id) == null)
                            return new ValidationResult("Invalid NationalityId");
                        break;
                    case "YearOfStudy":
                        if (dbContext.YearOfStudy.Find(id) == null)
                            return new ValidationResult("Invalid YearOfStudyId");
                        break;
                    case "Department":
                        if (dbContext.Departments.Find(id) == null)
                            return new ValidationResult("Invalid DepartmentId");
                        break;
                    case "ApplicationStatus":
                        if (dbContext.ApplicationStatuses.Find(id) == null)
                            return new ValidationResult("Invalid ApplicationStatusId");
                        break;
                }
            }

            return ValidationResult.Success;
        }
    }
}
