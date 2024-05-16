using EmployeeManagerApi.Model.DTO;
using EmployeeManagerApi.Model;

namespace EmployeeManagerApi.Interface
{
    public interface IUserService
    {
        public Task<Employee> Login(LoginDTO loginDTO);
        public Task<SuccessLogin> Register(EmployeeUserDTO employeeDTO);
    }


}
