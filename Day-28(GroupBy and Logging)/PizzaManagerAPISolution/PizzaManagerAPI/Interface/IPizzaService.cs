using PizzaManagerAPI.Model;

namespace PizzaManagerAPI.Interface
{
    public interface IPizzaService
    {
        public Task<List<Pizza>> GetAllAvailablePizza();
    }
}
