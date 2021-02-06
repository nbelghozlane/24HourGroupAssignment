using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(8000)]
        public string Text { get; set; }

        public int CommentId { get; set; }
    }
}
