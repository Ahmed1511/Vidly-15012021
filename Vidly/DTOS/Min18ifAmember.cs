using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTOS
{
    public class Min18ifAmember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerDto)validationContext.ObjectInstance;
            if (customer.MembershipDtoID == MemberShipType.UnKnown || customer.MembershipDtoID == MemberShipType.PayasYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.DateofBirth == null)
            {
                return new ValidationResult("Birth Date Is Required.");
            }

            var age = DateTime.Today.Year - customer.DateofBirth.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("customer should be at lset 18 y");

        }
    }
}