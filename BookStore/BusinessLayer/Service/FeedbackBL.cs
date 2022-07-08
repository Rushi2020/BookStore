using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedbackBL:IFeedbackBL
    {
        IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }

        public string AddFeedback(FeedbackModel feedbackModel, int id)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedbackModel, id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<GetFeedbackModel> GetFeedback(int BookId)
        {
            try
            {
                return this.feedbackRL.GetFeedback(BookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
