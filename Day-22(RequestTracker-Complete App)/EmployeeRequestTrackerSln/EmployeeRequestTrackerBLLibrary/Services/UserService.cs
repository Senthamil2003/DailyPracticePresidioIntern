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
        public Task<Solution> UpdateProblemStatus(int solutionid,int requestid,string comment);
        public Task<Feedback> AddFeedback(Feedback feedback);
        public Task<Solution> RespondToSolution(int id,string commnet);
        public Task<Request> GetRequest(int id);
        public Task<List<Solution>> ViewSolution(int id);
        public Task<Solution> GetSolution(int id);
       


    }
}
