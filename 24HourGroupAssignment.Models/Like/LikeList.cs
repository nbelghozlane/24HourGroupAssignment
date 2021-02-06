using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Models.Like
{
    public class LikeList
    {
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
