using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface EmployeeService
    {
        public Task<(string role, int employeeId)> Login(string name ,string password);
        public Task<Employee> Register(Employee employee);
        public Task<List<Feedback>> GetFeedbacks(int id);
        public Task<Employee> GetEmployee(int id);
        public Task<List<Solution>> GivenSolutions(int id);
        public Task<List<Request>> RaisedRequests(int id);
        public Task<List<Request>> GetClosedList(int id);

        



    }
}
