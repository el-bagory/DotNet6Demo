using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [ConcurrencyCheck]
        public string? FullName { get; set; }
        [ConcurrencyCheck]
        public string? Address { get; set; }
        [ConcurrencyCheck]

        public bool? Sex { get; set; }
        [ConcurrencyCheck]

        public string? Avatar { get; set; }
        [ConcurrencyCheck]

        public string? PhotoName { get; set; }
        [ConcurrencyCheck]

        public virtual ICollection<Post>? Posts {get; set;}
        [ConcurrencyCheck]

        public float? Salary { get; set; }
        [ConcurrencyCheck]        

        public DateTime? HireDate { get; set; }
        [ConcurrencyCheck]

        public bool? IsActive { get; set; }
        [ConcurrencyCheck]

        public string? CvName { get; set; }
        [ConcurrencyCheck]

        public int? DepartmentId { get; set; }
        [ConcurrencyCheck]

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        [ConcurrencyCheck]
      
        public int? ProjectId { get; set; }
        [ConcurrencyCheck]
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
        [ConcurrencyCheck]
      
        public int? DistrictId { get; set; }
        [ConcurrencyCheck]
        [ForeignKey("DistrictId")]
        public District? District { get; set; }

        // [TimeStamp]
        public byte[] RowVersion { get; set; }
    }
}