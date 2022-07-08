using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public string AddFeedback(FeedbackModel feedbackModel,int id);
        List<GetFeedbackModel> GetFeedback(int BookId);

    }
}
