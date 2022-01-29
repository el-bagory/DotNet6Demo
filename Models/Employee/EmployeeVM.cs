using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace Demo.Models.Employee
{
    public class EmployeeVM
    {
        public string? Id { get; set; }

        // [Required(ErrorMessage = "Enter Employee Salary")]

        // public int SSN { get; set; }

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public bool? Sex { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }


        [Required(ErrorMessage = "Enter Employee Salary")]
        [Range(5000, 20000, ErrorMessage = "Range From 5000 to 20000")]
        public float? Salary { get; set; }

        [Required(ErrorMessage = "Enter Employee Hire Date")]
        public DateTime? HireDate { get; set; }

        public bool? IsActive { get; set; }

        public string? CvName { get; set; }

        public string? PhotoName { get; set; }
       
        [Required(ErrorMessage = "Upload Employee Photo")]
        public IFormFile? Photo { get; set; }

        [Required(ErrorMessage = "Upload Employee Cv")]
        public IFormFile? Cv { get; set; }

        [Required(ErrorMessage = "Choose Employee Department")]
        public int? DepartmentId { get; set; }
      
        public int? DistrictId { get; set; }

        [Required(ErrorMessage = "Choose Employee Department")]
        public int? ProjectId { get; set; }
        
        public string? DepartmentName { get; set; }
      
        public string? DistrictName { get; set; }

        public string? ProjectName { get; set; }
        
        

    }
}