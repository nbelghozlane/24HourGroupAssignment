
using _24HourGroupAssignment.Data;
using _24HourGroupAssignment.Models.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    OwnerId = _userId,
                    PostId = model.PostId,
                    CreatedUtc = DateTimeOffset.Now,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<LikeList> GetAllLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //Filter database
                var entity = ctx.Likes.Where(e => e.OwnerId == _userId)
                .Select(
                     e => new LikeList
                     {
                         LikeId = e.LikeId,
                         PostId = e.PostId,
                         CreatedUtc = e.CreatedUtc,
                     });
                return entity.ToArray();


            }
        }
    }
}
