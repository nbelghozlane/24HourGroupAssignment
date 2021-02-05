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
    public class LikeController : ApiController
    {
        private LikeService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new LikeService(userId);
            return noteService;
        }
        public IHttpActionResult Get()
        {
            LikeService likeService = CreateNoteService();
            var Like = likeService.GetAllLikes();
            return Ok(Like);
        }
        public IHttpActionResult Post(LikeCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.CreateLike(note))
                return InternalServerError();

            return Ok("The Like was successfullu created");
        }

    }
}
