using AirportManagement.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class AddHanger
    {
        public AddHanger() { }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter alphabets and spaces")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Location must be between 3 and 50 characters.")]
        public string HangerLocation { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Capacity must contain only numbers.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1.")]
        public int HangerCapacity { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name should contain only alphabets and space.")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Social Security Number must have numbers in format .(ddd-dd-dddd)")]
        public string SocialSecuirtyNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [CustomDateValidation(ErrorMessage = "Date of Birth should be less than today's date.")]
        [AgeValidation(ErrorMessage = "Age should greater than 23")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[1-9]\d{9}$", ErrorMessage = "Please enter a valid 10-digit mobile number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "House number must be between 1 and 100 characters.")]
        public string HouseNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City should contain only alphabets and space.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "City name must be between 3 and 100 characters.")]
        public string City { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State should contain only alphabets and space.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "State name must be between 3 and 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country should contain only alphabets and space.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Country name must be between 3 and 50 characters.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "PIN Number should contain exactly 7 digits.")]
        public string PinNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 150 characters.")]
        public string AddressLine { get; set; }
    }
}