using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface FeedbackService
    {
        public Task<Feedback> AddFeedback(Feedback feedback);
        public Task<List<Feedback>> FeedbackList(Feedback request);
        public Task<Feedback> GetFeedback(int id);
       

    }
}
