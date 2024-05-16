using EmployeeManagerApi.Model.DTO;

namespace EmployeeManagerApi.Interface
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(EmployeeUserDTO login);
    }
}
