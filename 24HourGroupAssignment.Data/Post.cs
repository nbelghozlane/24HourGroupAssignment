using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Data
{
    public class Post
    {
        //Amel
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid Author { get; set; }// Guid is a unique identifier for the user
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual List<Like> Likes { get; set; } = new List<Like>();
        // public virtual List<Comment> Comments { get; set; }
    }
}
