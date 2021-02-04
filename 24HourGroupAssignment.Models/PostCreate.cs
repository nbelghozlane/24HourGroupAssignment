using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "There are tooo many caracters in this field, 15 characters is the maximum")]
        public string Title { get; set; }
        [Required]
        [MinLength(20,ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(500,ErrorMessage = "There are tooo many caracters in this field, 15 characters is the maximum")]
        public string Text { get; set; }

    }
}
