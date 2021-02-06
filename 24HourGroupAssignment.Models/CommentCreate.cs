using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(10000, ErrorMessage = "Must have 10,000 characters or less in this field.")]
        public string Text { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }
    }
}
