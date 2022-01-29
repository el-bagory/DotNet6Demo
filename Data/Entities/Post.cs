using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? AutherId { get; set; }

        [ForeignKey("AutherId")]
        public ApplicationUser? Auther { get; set; }
        public virtual ICollection<PostImage>? PostImages {get; set;}

        public virtual ICollection<Tag>? Tags {get; set;}

    }
}