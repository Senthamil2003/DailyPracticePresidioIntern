using PizzaManagerAPI.Model;
using PizzaManagerAPI.Model.DTO;

namespace PizzaManagerAPI.Interface
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(Customer data);
    }
}
