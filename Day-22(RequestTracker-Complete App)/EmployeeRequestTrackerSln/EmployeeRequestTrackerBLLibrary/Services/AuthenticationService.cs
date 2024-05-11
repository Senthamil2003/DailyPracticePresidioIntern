using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface AuthenticationService
    {
        public Task<(string role, int employeeId)> Login(string name, string password);
        public Task<Employee> Register(Employee employee);
    }
}
