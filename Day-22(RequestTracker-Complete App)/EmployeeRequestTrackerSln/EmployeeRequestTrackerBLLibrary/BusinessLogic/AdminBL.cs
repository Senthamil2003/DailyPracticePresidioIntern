using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using EmployeeRequestTrackerDALLibrary.JoinedRepository;
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
    public class AdminBL : UserBL, AdminService
    {
        readonly IRepository<int, Employee> _Employeerepo;
        readonly IRepository<int, Feedback> _feedbackrepository;
        readonly IRepository<int, Request> _requestrepo;
        readonly IRepository<int, Solution> _solutionRepository;
        public AdminBL() {
            _solutionRepository = new SolutionRepository(new RequestTrackerContext());
            _Employeerepo = new EmployeeJoinedRepository(new RequestTrackerContext());
            _feedbackrepository = new FeedbackJoinedRepository(new RequestTrackerContext());
            _requestrepo = new RequestJoinedRepository(new RequestTrackerContext());
        }
        public async Task<List<Request>> GetClosedList(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Request> requests = employee.ClosedRequest;
                if (requests.Count > 0)
                {
                    return requests;
                }
                throw new NoDataFoundException("No requests are closed by employee");

            }
            catch
            {
                throw;
            }
        }


        public async Task<List<Solution>> GivenSolutions(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Solution> solutions = employee.GivenSolutions;
                if (solutions.Count > 0)
                {
                    return solutions;
                }
                throw new NoDataFoundException("No solutions are given by employee");

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Request>> RequestList()
        {
            try
            {
                await Console.Out.WriteLineAsync("inside repo");
                List<Request> requests = await _requestrepo.GetAll();
                return requests;

            }
            catch
            {
                throw;
            }
        }

        public Task<Solution> AddSolution(Solution solution)
        {
            try
            {
               
               return _solutionRepository.Add(solution);  

            }
            catch
            {
                throw;
            }
        }

        public async Task<Request> UpdateRequestStatus(int id)
        {
            try
            {
                Request request = await _requestrepo.Get(id);
                request.RequestStatus = "Closed";
                await _requestrepo.Update(request);
                return request;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Feedback>> ViewFeedback(int id)
        {
            try
            {
                Employee employee = await _Employeerepo.Get(id);
                List<Feedback> feedbacks = employee.GivenFeedbacks;
                if (feedbacks.Count > 0)
                {
                    return feedbacks;
                }
                throw new NoDataFoundException("No feedbac available");
            }
            catch
            {
                throw;
            }
        }
    }
}
