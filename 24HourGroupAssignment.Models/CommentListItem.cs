using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models
{
    public class CommentListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [Display(Name="Created By:")]
        public Guid Author { get; set; }
    }
}
