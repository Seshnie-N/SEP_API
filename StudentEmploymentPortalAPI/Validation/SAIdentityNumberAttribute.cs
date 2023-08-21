using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace StudentEmploymentPortalAPI.Validation
{
    public class SAIdentityNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (LuhnAlgorithm(value.ToString()))
                return ValidationResult.Success;
            else
                return new ValidationResult("Invalid ID Number");
        }

        private bool LuhnAlgorithm(string? iDNumber)
        {
            List<int> parsedId = new();

            if (iDNumber == null)
                return false;

            if (iDNumber.Length != 13)
                return false;

            for (int i = 0; i < 13; i++)
            {
                if (!char.IsNumber(iDNumber[12 - i]))
                    return false;

                int d;
                if (i%2 == 1 )
                    d = int.Parse(iDNumber[12 - i].ToString()) * 2;
                else
                    d = int.Parse(iDNumber[12 - i].ToString());

                if (d > 9)
                    parsedId.Add(d-9);
                else
                    parsedId.Add(d);
            }

            if (parsedId.Sum() % 10 == 0)
                return true;

            return false;
        }
    }
}
