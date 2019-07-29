using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMvcApp.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 11)

                return ValidationResult.Success;
            if (customer.DoB == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.DoB.Year;

            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Should be an adult");
        }


           //return base.IsValid(value, validationContext);
        }
    }
