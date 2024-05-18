using EmployeeManagerApi.Model.DTO;
using EmployeeManagerApi.Model;

namespace EmployeeManagerApi.Interface
{
    public interface IAuthenticationService
    {
        public Task<SuccessLogin> Login(LoginDTO loginDTO);
        public Task<SuccessLogin> Register(EmployeeUserDTO employeeDTO);
    }


}
