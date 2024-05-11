using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface UserService
    {
        public Task<Employee> GetEmployee(int id);
        public Task<Request> RaiseRequest(Request request);
        public Task<Request> CheckStatus(int id);
        public Task<List<Request>> RaisedRequests(int id);
        public Task<Request> UpdateProblemStatus(int id);
        public Task<Feedback> AddFeedback(Feedback feedback);
        public Task<Solution> RespondToSolution(int id,string commnet);
        public Task<Request> GetRequest(int id);

    }
}
