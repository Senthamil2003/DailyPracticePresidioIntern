﻿using EmployeeRequestTrackerBLLibrary.Services;
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
    public class UserBL:UserService
    {
        readonly IRepository<int, Employee> _Employeerepo;
        readonly IRepository<int, Feedback> _feedbackrepository;
        readonly IRepository<int, Request> _requestrepo;
        readonly IRepository<int, Solution> _solutionRepository;

        public UserBL() {
            _solutionRepository = new SolutionJoinedRepository(new RequestTrackerContext());
            _Employeerepo = new EmployeeRepository(new RequestTrackerContext());
            _feedbackrepository = new FeedbackJoinedRepository(new RequestTrackerContext());
            _requestrepo = new RequestJoinedRepository(new RequestTrackerContext());
        }

        public async Task<Feedback> AddFeedback(Feedback feedback)
        {
            try
            {
                return await _feedbackrepository.Add(feedback);

            }
            catch
            {
                throw;
            }
        }

        public async Task<Request> CheckStatus(int id)
        {
            try
            {
                Request request = await _requestrepo.Get(id);
                if (request != null)
                {
                    return request;
                }
                throw new NoDataFoundException("No request found for the given Id");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                Employee employee = await _Employeerepo.Get(id);
                if (employee != null)
                {
                    return employee;
                }
                throw new NoDataFoundException("No Employee Found");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Request> GetRequest(int id)
        {
            try
            {
                Request request =await _requestrepo.Get(id);
               if(request != null)
                {
                    return request;
                }
                throw new NoDataFoundException("No Request found for given id");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Solution> GetSolution(int id)
        {
            try
            {
               Solution solution= await _solutionRepository.Get(id);
             if (solution != null)
                    return solution;
                throw new NoDataFoundException("No solution Available for give Id");
            }
            catch
            {
                throw;

            }
        }

        public async Task<List<Request>> RaisedRequests(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Request> requests = employee.RaisedRequests;
                if (requests.Count > 0)
                {
                    return requests;
                }
                throw new NoDataFoundException("No requests are raised by employee");

            }
            catch
            {
                throw;
            }
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            try
            {
                await Console.Out.WriteLineAsync("inside BL--"+request.RequestMessage);
                await _requestrepo.Add(request);
                return request;
            }
            catch
            {
                throw;
            }

        }

        public async Task<Solution> RespondToSolution(int id,string comment)
        {
            try
            {
               Solution solution= await _solutionRepository.Get(id);
                solution.RaiserComment = comment;
                await _solutionRepository.Update(solution);
                return solution;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Solution> UpdateProblemStatus(int solutionid,int requestnumber,string comment)
        {
            try
            {
                Solution solution=await _solutionRepository.Get(solutionid);
                solution.IsWorked= true;
                solution.RaiserComment= comment;
                await _solutionRepository.Update(solution);
                Request request = await _requestrepo.Get(requestnumber);
                request.ProblemStatus = true;
                request.RequestClosedBy = solution.AnsweredEmployeeId;
                await _requestrepo.Update(request);
                return solution;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Solution>> ViewSolution(int id)
        {
            try
            {
                Request request = await _requestrepo.Get(id);
                List<Solution> solutions = request.solutions;
                if (solutions.Count > 0)
                {
                    return solutions;
                }
                throw new NoDataFoundException("No Solution for the given Request");

            }
            catch
            {
                throw;
            }


        }
    }
}
