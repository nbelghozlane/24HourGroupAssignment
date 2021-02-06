﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public virtual List<ReplyListItem> Replies { get; set; }
        public int PostId { get; set; }
    }
}
