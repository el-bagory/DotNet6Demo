using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Demo.Data.Entities
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? DistrictName { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]

        public City? City { get; set; }

        public ICollection<ApplicationUser>? Empoloyees { get; set; }


    }
}