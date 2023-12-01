using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportManagement
{
    public class AgeValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime dateOfBirth)
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.Month < dateOfBirth.Month ||
                    (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
                {
                    age--;
                }

                // Check if age is less than 23
                if (age < 23)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }


            return ValidationResult.Success;
        }
    }
}