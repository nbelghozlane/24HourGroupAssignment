using _24HourGroupAssignment.Models;
using _24HourGroupAssignment.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourGroupAssignment.Controllers
{
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
                var postService = new PostService(userId);
            return postService;
        }
        public IHttpActionResult GetAllPosts()
        {
            PostService postService = CreatePostService();
            //call my GetPosts from PostService
            var posts = postService.GetPosts();
            return Ok(posts);
        }
        public IHttpActionResult Post([FromBody]PostCreate post)
        {
            //Check if model state is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService Service = CreatePostService();

            //Call my CreatePost From PostService and make sure the Post was created
            if (!Service.CreatePost(post))
                return InternalServerError();
            return Ok("Your Post Was Successfully Created.");
        }
        public IHttpActionResult GetPostById([FromUri]int Id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(Id);
            return Ok(post);
        }
        public IHttpActionResult Put(PostEdit Post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePostService();
            if (!service.UpdatedPost(Post))
                return InternalServerError();
            return Ok("The Post Was Successfully Updated.");
        }

        public IHttpActionResult Delete(int Id)
        {
            var service = CreatePostService();
            if (!service.DeletePost(Id))
                return InternalServerError();
            return Ok("The Post Was Successfully deleted");
        }
    }
}
