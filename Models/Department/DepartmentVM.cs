using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Department
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        [MaxLength(20, ErrorMessage = "Max Length 30")]
        public string? DepartmentName { get; set; }        
        public string? DepartmentCode { get; set; }
    }
}