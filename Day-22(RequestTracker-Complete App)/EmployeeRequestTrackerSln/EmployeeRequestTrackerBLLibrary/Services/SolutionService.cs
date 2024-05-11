using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface SolutionService
    {
        public Task<Solution> CreateSolution(Solution solution);
        public Task<double> SolutionFeedback(int id);
        public Task<Solution> GetSolution(int id);
        public Task<List<Solution>> SolutionList();
        public Task<List<Feedback>> GetAllFeedback(int id);
    }
}
