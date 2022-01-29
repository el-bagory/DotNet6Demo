using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Entities
{
    public class PostImage
    {
        [Key]
        public int Id { get; set; }

        public string? imgPath { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post? Post { get; set; }

        
    }
}