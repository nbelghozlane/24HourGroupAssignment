﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        //[ForeignKey(nameof(Comments))]
        //public int CommentId { get; set; }
        //public virtual List<Comment> Comments { get; set; }
       
    }
}
