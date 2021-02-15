using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Helpers
{
    /// <summary>
    /// Validates that given date does not surpass 3 month from current date
    /// </summary>
    public class ThreeMonthAheadValidation : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Date value should not surpass 3 months from now";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            if (dateValue.Date > DateTime.Now.AddMonths(3).Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
