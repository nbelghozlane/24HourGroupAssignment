using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models.Post
{
    public class PostList
    {
        //Get all Posts
        public int PostId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        // public virtual List<Comment> Comments { get; set; }
        public int Likes { get; set; }
    }
}
