using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string? TageName { get; set; }
    }
}