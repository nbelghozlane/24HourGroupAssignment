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
    public class ReplyController : ApiController
    {
        private ReplyService CreatedReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

        public IHttpActionResult Get()
        {
            ReplyService replyService = CreatedReplyService();
            var replies = replyService.GetReplies();
            return Ok(replies);
        }

        public IHttpActionResult Reply(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatedReplyService();

            if (!service.CreatedReply(reply))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreatedReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }

        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatedReplyService();

            if (!service.UpdateReply(reply))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatedReplyService();

            if (!service.DeleteReply(id))
                return InternalServerError();

            return Ok();
        }
    }
}
