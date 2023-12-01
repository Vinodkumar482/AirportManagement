using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class AddPlane
    {
        [Required(ErrorMessage = "Manufacturer Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Manufacturer Name should contain only alphabets and spaces.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string ManufacturerName { get; set; }



        [Required(ErrorMessage = "Registration Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Registration Number should be 10 digit numeric.")]
        public string RegistrationNo { get; set; }

        [Required(ErrorMessage = "Owner Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Owner Name should contain only alphabets and spaces.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string OwnerName { get; set; }


        [Required(ErrorMessage = "Model Number is required.")]
        [RegularExpression(@"^[A-Za-z0-9-\s]+$", ErrorMessage = "Model Number should contain only alphabets, numbers, and hyphens.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Model Number must be between 3 and 50 characters.")]
        public string ModelNo { get; set; }



        [Required(ErrorMessage = "Plane Name is required.")]
        //[RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Plane Name should contain only alphabets and spaces.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string PlaneName { get; set; }



        [Required(ErrorMessage = "Capacity is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Capacity should contain only numbers.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1.")]
        public int Capacity { get; set; }



        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 characters.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "House No is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "House number must be between 1 and 100 characters.")]
        public string HouseNo { get; set; }



        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City should contain only alphabets and spaces.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "City name must be between 3 and 100 characters.")]
        public string City { get; set; }



        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "State should contain only alphabets and spaces.")]
        [Required(ErrorMessage = "State name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "State name must be between 3 and 50 characters.")]
        public string State { get; set; }



        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Country should contain only alphabets and spaces.")]
        [Required(ErrorMessage = "Country name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Country name must be between 3 and 50 characters.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "*Required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 150 characters.")]
        public string AddressLine { get; set; }


        [Required(ErrorMessage = "Pin No is required.")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "Pin No should contain exactly 7 digits.")]
        public string PinNo { get; set; }
    }
}