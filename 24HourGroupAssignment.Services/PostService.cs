using _24HourGroupAssignment.Data;
using _24HourGroupAssignment.Models;
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
            using(var ctx=new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //See all Posts
        public IEnumerable<PostList> GetPosts()
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity = ctx.Posts.Where(e => e.Author == _userId)//filter the database

                    .Select(e => new PostList
                    {
                        PostId = e.Id,
                        Title = e.Title,
                        //Comments = e.Comments,
                        CreatedUtc = e.CreatedUtc

                    });
                return entity.ToArray();
                    

                    
                    
            }
                 
        }
        public PostDetails GetPostById(int id)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(e => e.Id==id && e.Author == _userId);
                return new PostDetails
                {
                    PostId = entity.Id,
                    PostTitle = entity.Title,
                    PostText = entity.Text,
                    //Comments=entity.Comments,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

    }
}

