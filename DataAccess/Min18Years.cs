using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId==MemberShipType.Unkown|| customer.MemberShipTypeId == MemberShipType.Payasyougo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthday is Empty");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("You shoud to be at least 18 years old");




        }
    }
}
