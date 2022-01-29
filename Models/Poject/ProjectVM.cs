using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Project
{
    public class ProjectVM
    {
        public int Id { get; set; }

        // [Required(ErrorMessage = "Enter Project Name")]
        public string? ProjectName { get; set; }

        // [Required(ErrorMessage = "Enter Project Description")]
        public string? ProjectDescription { get; set; }

        // [Required(ErrorMessage = "Enter Estimated Budget")]
        public int? EstimatedBudget { get; set; }

        // [Required(ErrorMessage = "Enter Total Amount Spent")]

        public int? TotalAmountSpent { get; set; }

        // [Required(ErrorMessage = "Enter Estimated Project Duration")]
        public int? EstimatedProjectDuration { get; set; }
        
        // [Required(ErrorMessage = "Enter Status")]
        public string? ProjectStatus { get; set; }

        // [Required(ErrorMessage = "Enter Progress")]
        public int? ProjectProgress { get; set; }

        // [Required(ErrorMessage = "Enter Leader Name")]
        public string? LeaderId { get; set; }

        public string? Client { get; set; }

    }
}