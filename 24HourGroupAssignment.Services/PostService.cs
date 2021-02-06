using _24HourGroupAssignment.Data;
using _24HourGroupAssignment.Models;
using _24HourGroupAssignment.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourGroupAssignment.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }

        //Create an instance of post
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Author = _userId,
                    Text = model.Text,
                    Title = model.Title,
                    // CommentId = model.commentId,
                    CreatedUtc = DateTimeOffset.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //See all Posts
        public IEnumerable<PostList> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Where(e => e.Author == _userId)//filter the database

                    .Select(e => new PostList
                    {
                        PostId = e.Id,
                        Title = e.Title,
                        //Comments = e.Comments,
                        CreatedUtc = e.CreatedUtc,
                        Likes = e.Likes.Count(), // Count method will return the number of likes each post has
                        Comments = e.Comments.Select(
                     x => new CommentListItem
                     {
                        CommentId=x.CommentId,
                         Text = x.Text,
                         
                     }).ToList()

            }); 
                return entity.ToArray();


            }

        }
        public PostDetails GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(e => e.Id == id && e.Author == _userId);
                return new PostDetails
                {
                    PostId = entity.Id,
                    PostTitle = entity.Title,
                    PostText = entity.Text,
                 
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                     Comments = entity.Comments.Select(
                     x => new CommentListItem
                     {
                         CommentId = x.CommentId,
                         Text = x.Text,

                     }).ToList()


                };
            }
        }

        public bool UpdatedPost(PostEdit post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.Id == post.PostId && e.Author == _userId);
                entity.Text = post.Text;
                entity.Title = post.Title;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeletePost(int PostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.Id == PostId && e.Author == _userId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
