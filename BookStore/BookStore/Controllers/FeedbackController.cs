using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackBL feedbackBL;

        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }

        [Authorize(Roles = Role.User)]
        [HttpPost("AddFeedback")]
        public ActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = this.feedbackBL.AddFeedback(feedbackModel, id);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Add feadback  successfull", Response = result });

                }
                return this.BadRequest(new { Success = true, message = " adding Feadback failed", Response = result });

            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetFeedback")]
        public ActionResult GetFeedback(int BookId)
        {
            try
            {
                var result = this.feedbackBL.GetFeedback(BookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Feedback for the BookId is : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
