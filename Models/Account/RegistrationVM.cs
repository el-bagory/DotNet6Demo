using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Demo.Models.Account
{
    public class RegistrationVM
    {
        
        [Required(ErrorMessage = "Employee Name Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-CountryName")]
        public string? Address { get; set; }
        


        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Valid Mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage = "Min Len 3")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [Compare("Password",ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Avatar Required")]
        [Display(Name = "Avatar")]
        public string? Avatar { get; set; }
        public string? PhotoName { get; set; }

        public string? Sex { get; set; }

    }
}
