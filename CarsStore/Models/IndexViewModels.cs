using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI.Models
{
    public class SpecialsFeaturedCarViewModel
    {
        public List<Car> FeaturedCars { get; set; }
        public List<Specials> Specials { get; set; }
    }

    public class SpecialsListViewModel
    {
        public List<Specials> Specials { get; set; }
    }

    public class ContactViewModel : IValidatableObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            var nameType = Name as String;

            if (Phone != null)
            {
                var phoneIsValid = Utility.ValidatePhoneNumber(Phone);

                if (!phoneIsValid)
                    errors.Add(new ValidationResult("Please enter valid phone number", new[] { "Phone" }));
            }

            if (Email != null)
            {
                var emailIsValid = Utility.ValidateEmail(Email);

                if (!emailIsValid)
                    errors.Add(new ValidationResult("Please enter valid email", new[] { "Email" }));
            }


            if (string.IsNullOrEmpty(Name))
            
                errors.Add(new ValidationResult("Please enter your name", new[] { "Name" }));
            

            if (nameType == null)
            
                errors.Add(new ValidationResult("Please enter valid  name", new[] { "Name" }));
            

            if (string.IsNullOrEmpty(Message))
            
                errors.Add(new ValidationResult("Please include message", new[] { "Message" }));
            

            if (string.IsNullOrEmpty(Email))
            
                errors.Add(new ValidationResult("Please add email", new[] { "Email" }));
            

            if (string.IsNullOrEmpty(Phone))
            
                errors.Add(new ValidationResult("Please add  phone number", new[] { "Phone" }));
            

            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Phone))
            {
                errors.Add(new ValidationResult("Please add email or phone number", new[] { "Email" }));
                errors.Add(new ValidationResult("Please add email or phone number", new[] { "Phone" }));
            }

            return errors;
        }
    }
}