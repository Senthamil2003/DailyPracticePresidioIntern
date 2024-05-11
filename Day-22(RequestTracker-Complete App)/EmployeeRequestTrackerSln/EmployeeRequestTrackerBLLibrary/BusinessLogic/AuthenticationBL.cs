using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using EmployeeRequestTrackerDALLibrary.Repository;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.BusinessLogic
{
    public class AuthenticationBL : AuthenticationService
    {
        readonly IRepository<int, Employee> _Employeerepo;
        public AuthenticationBL()
        {
            _Employeerepo = new EmployeeRepository(new RequestTrackerContext());
        }
        public async Task<(string role, int employeeId)> Login(string name, string password)
        {
            try
            {
                List<Employee> employees = await _Employeerepo.GetAll();
                Employee employee =employees.FirstOrDefault(e => e.Name == name && e.PasswordCheck(password));
                if (employee != null)
                {

                    return (employee.Role, employee.EmployeeId);
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

    }
}
