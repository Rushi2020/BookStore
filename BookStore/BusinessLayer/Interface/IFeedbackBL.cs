﻿using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public string AddFeedback(FeedbackModel feedbackModel);
        List<GetFeedbackModel> GetFeedback(int BookId);

    }
}
