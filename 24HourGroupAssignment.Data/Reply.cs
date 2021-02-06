using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Data
{
    public class Reply
    {
        //Carlos

        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid Author { get; set; }

        [Required]

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModiefiedUtc { get; set; }
        
        [Required]
        [ForeignKey(nameof(Comments))]
        public int CommentId { get; set; }
        public virtual Comment Comments { get; set; }
    }
}
