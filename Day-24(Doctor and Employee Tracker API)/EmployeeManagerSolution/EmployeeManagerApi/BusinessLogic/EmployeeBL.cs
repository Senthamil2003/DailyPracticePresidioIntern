using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;

namespace EmployeeManagerApi.BusinessLogic
{
    public class EmployeeBL : EmployeeService
    {
        private readonly IReposiroty<int, Employee> _employeerepo;
        public EmployeeBL(IReposiroty<int ,Employee> employeeRepo) {
            _employeerepo=employeeRepo;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            try
            {
                    Employee employee= (await _employeerepo.Get()).FirstOrDefault(e=>e.Phone==phoneNumber);
                    if (employee!=null) {
                          return employee;
                    }
                    throw new NoEmployeeFoundException();

            }
            catch {
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
               return await _employeerepo.Get();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            try
            {
               Employee employee=await _employeerepo.Get(id);
                await Console.Out.WriteLineAsync("---------------------hi inside the bl-----------------------");
                if (employee!=null)
                {
                    employee.Phone = phoneNumber;
                    await _employeerepo.Update(employee);
                    return employee;
                }
                throw new NoEmployeeFoundException();


            }
            catch
            {
                throw;
            }
        }
    }
}
