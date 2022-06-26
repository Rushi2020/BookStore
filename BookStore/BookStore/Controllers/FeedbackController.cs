using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost("Add Feedback")]
        public ActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                string result = this.feedbackBL.AddFeedback(feedbackModel);
                if (result.Equals("Success:- Your Feedback is added Successfully"))
                {
                    return this.Ok(new { Success = true, message = result });
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

        [HttpGet("Get Feedback")]
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
