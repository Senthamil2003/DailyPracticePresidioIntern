using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using EmployeeRequestTrackerDALLibrary.Repository;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;

namespace EmployeeRequestTrackerBLLibrary.BusinessLogic
{
    public class EmployeeBL : EmployeeService
    {
        readonly IRepository<int, Employee> _Employeerepo;
        public EmployeeBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _Employeerepo = repo;
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

        public async Task<List<Feedback>> GetFeedbacks(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Feedback> feedbacks = (List<Feedback>)employee.GivenFeedbacks;

                if (feedbacks.Count > 0)
                {
                    return feedbacks;
                }
                throw new NoDataFoundException("No Feedback found");
            }
            catch
            {
                throw;

            }

        }

        public async Task<(string role,int  employeeId)> Login(string name, string password)
        {
            try
            {
                List<Employee> employees = await _Employeerepo.GetAll();
                Employee employee = employees.FirstOrDefault(e => e.Name == name && e.PasswordCheck(password));
                if (employee != null)
                {
                    
                    return (employee.Role,employee.EmployeeId);
                }
              
                throw new AuthenticationFailedException("Give the valid user name and password");

            }
            catch
            {
                throw;
            }



        }


        public async Task<Employee> Register(Employee employee)
        {
            try
            {
                return await _Employeerepo.Add(employee);

            }
            catch
            {
                throw;
            }

        }
        public async Task<List<Request>> GetClosedList(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Request> requests = (List<Request>)employee.ClosedRequest;
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


        public async Task<List<Request>> RaisedRequests(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Request> requests = (List<Request>)employee.RaisedRequests;
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
        public async Task<List<Solution>> GivenSolutions(int id)
        {
            try
            {
                Employee employee = await GetEmployee(id);
                List<Solution> solutions = (List<Solution>)employee.GivenSolutions;
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

    }
}
