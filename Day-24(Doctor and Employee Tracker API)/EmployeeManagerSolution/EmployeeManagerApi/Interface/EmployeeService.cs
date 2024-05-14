using EmployeeManagerApi.Model;

namespace EmployeeManagerApi.Interface
{
    public interface EmployeeService
    {
        public Task<Employee> GetEmployeeByPhone(string phoneNumber);
        public Task<Employee> UpdateEmployeePhone(int id, string phoneNumber);
        public Task<IEnumerable<Employee>> GetEmployees();

    }
}
