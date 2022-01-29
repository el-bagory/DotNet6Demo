using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace Demo.Models.ApplicationUser
{
    public class ApplicationUserVM
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Enter Employee Name")]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        [MaxLength(20, ErrorMessage = "Max Length 30")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Enter Employee Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-CountryName")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Enter Employee Address")]
        public string? Email { get; set; }
        
        public IFormFile? PhotoUrl { get; set; }
        public string? PhotoName { get; set; }
        public bool? Sex { get; set; }


        [Required(ErrorMessage = "Enter Employee Salary")]

        public int SSN { get; set; }

        [Required(ErrorMessage = "Enter Employee Salary")]
        [Range(5000, 20000, ErrorMessage = "Range From 5000 to 20000")]
        public float? Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public bool? IsActive { get; set; }

        public string? CvName { get; set; }

        public IFormFile? CvUrl { get; set; }

        public string? DepartmentName { get; set; }
      
        public string? DistrictName { get; set; }

        public int? ProjectId { get; set; }


    }
}