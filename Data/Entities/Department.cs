using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Demo.Data.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? DepartmentName { get; set; }

        [StringLength(20)]
        public string? DepartmentCode { get; set; }

        public ICollection<ApplicationUser>? Empoloyees { get; set; }

        public virtual ICollection<Project>? Project { get; set; }

        // public string? ManagerId { get; set; }

        // [ForeignKey("AutherId")]
        // public ApplicationUser? Manager { get; set; } 

    }
}