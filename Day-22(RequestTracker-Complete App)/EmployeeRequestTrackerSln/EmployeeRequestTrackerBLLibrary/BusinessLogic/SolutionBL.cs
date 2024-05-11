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
    public class SolutionBL : SolutionService
    {
        IRepository<int,Solution> _solutionRepository;
        public SolutionBL() {
            _solutionRepository = new SolutionRepository(new RequestTrackerContext());
        }
        public async Task<Solution> CreateSolution(Solution solution)
        {
            try
            {
                  return  await _solutionRepository.Add(solution);

            }
            catch {
                throw;
            }
        }

        public async Task<List<Feedback>> GetAllFeedback(int id)
        {
            try
            {
                Solution solution=await _solutionRepository.Get(id);
                if (solution?.Feedbacks?.Count > 0)
                {
                    return (List<Feedback>)solution.Feedbacks;
                }
                throw new NoDataFoundException("No feedback given for solution");
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
                Solution solution =await _solutionRepository.Get(id);
                if(solution != null) {
                    return solution;
                }
                throw new  NoDataFoundException("No Solution found for the id");
            }
            catch
            {
                throw;
            }
        }

        public async Task<double> SolutionFeedback(int id)
        {
            try
            {
                List<Feedback> feedbacks=await GetAllFeedback(id);
                double sum = 0;
                foreach (Feedback feedback in feedbacks)
                {
                    sum += feedback.Rating;
                }
                return sum/feedbacks.Count;
              
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<Solution>> SolutionList()
        {
            try
            {
                List<Solution> solutions= await _solutionRepository.GetAll();
                if(solutions.Count > 0)
                {
                    return solutions;
                }
                throw new NoDataFoundException("No solution available for the request");
            }
            catch
            {
                throw;
            }
        }
    }
}
