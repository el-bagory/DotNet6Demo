using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectDescription { get; set; }

        public int? EstimatedBudget { get; set; }
        public int? TotalAmountSpent { get; set; }
        public int? EstimatedProjectDuration { get; set; }
        public string? ProjectStatus { get; set; }
        public int? ProjectProgress { get; set; }

        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public string? Client { get; set; }

        // public ICollection<ApplicationUser>? Empoloyees { get; set; }

        // public string? LeaderName { get; set; }
        public string? LeaderId { get; set; }
        [ForeignKey("LeaderId")]
        public ApplicationUser? Leader { get; set; }






    }
}