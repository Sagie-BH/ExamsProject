using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidateEmailListAnnotation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] array = value as string[];

            if (array != null)
            {
                //if (array.Length == 0)
                //    return new ValidationResult("At least one element is required.");

                EmailAddressAttribute emailAttribute = new EmailAddressAttribute();

                foreach (string str in array)
                {
                    if (!emailAttribute.IsValid(str))
                    {
                        return new ValidationResult("At least one element is not valid email address.");
                    }
                }

                return ValidationResult.Success;
            }

            return base.IsValid(value, validationContext);
        }
    }
}
