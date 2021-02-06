using _24HourGroupAssignment.Data;
using _24HourGroupAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Author = _userId,
                    Text = model.Text,
                    PostId=model.PostId,//Added
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Text = e.Text,
                                    CreatedUtc = e.CreatedUtc,
                                    Replies=e.Replies.Select(z => new ReplyListItem
                                    {
                                        Id=z.Id,
                                        Text=z.Text,
                                    }).ToList()

                                }
                        );

                return entity.ToList();
            }
        }

        public CommentDetail GetCommentById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId && e.Author == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        Replies = entity.Replies.Select(z => new ReplyListItem
                        {
                            Id = z.Id,
                            Text = z.Text,
                        }).ToList()
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.Author == _userId);

                entity.CommentId = model.CommentId;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId && e.Author == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
