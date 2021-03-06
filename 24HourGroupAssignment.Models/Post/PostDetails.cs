﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models.Post
{
    public class PostDetails
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public List<CommentListItem> Comments { get; set; }
    }
}
