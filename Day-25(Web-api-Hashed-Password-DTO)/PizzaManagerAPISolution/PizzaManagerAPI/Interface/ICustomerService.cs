using PizzaManagerAPI.Model.DTO;

namespace PizzaManagerAPI.Interface
{
    public interface ICustomerService
    {
        public Task<SuccessRegister> Login(LoginDTO loginDTO);
        public Task<SuccessRegister> Register(RegisterDTO employeeDTO);
    }
}
