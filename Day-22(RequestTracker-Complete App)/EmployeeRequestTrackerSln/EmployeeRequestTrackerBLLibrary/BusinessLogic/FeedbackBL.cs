using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using EmployeeRequestTrackerDALLibrary.Repository;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.BusinessLogic
{
    public class FeedbackBL : FeedbackService
    {
        IRepository<int, Feedback> _feedbackrepository;
        public FeedbackBL() 
        {
            _feedbackrepository = new FeedbackRepository(new RequestTrackerContext());
        }
        public async Task<Feedback> AddFeedback(Feedback feedback)
        {
            try
            {
               return await _feedbackrepository.Add(feedback);  

            }
            catch {
                throw;
            }
        }

      
        public async Task<List<Feedback>> FeedbackList(Feedback request)
        {
            try
            {
                List<Feedback> feedbacks= await _feedbackrepository.GetAll();
                if (feedbacks.Count > 0)
                {
                    return feedbacks;
                }
                throw new NoDataFoundException("Feedback is empty :->)");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Feedback> GetFeedback(int id)
        {
            try
            {
              return await _feedbackrepository.Get(id);
              
            }
            catch
            {
                throw;
            }
        }
    }
}
