using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;

namespace PizzaManagerAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IReposiroty<int, Pizza> _pizzarepo;

        public PizzaService(IReposiroty<int,Pizza> pizzarepo) {
            _pizzarepo= pizzarepo;
        }
        public async Task<List<Pizza>> GetAllAvailablePizza()
        {
            try
            {
                List<Pizza> result = (await _pizzarepo.Get()).Where(e => e.Quantity > 0).ToList();
                if (result.Count > 0)
                {
                    return result;

                }
                throw new Exception("No Pizza available for deliver");
              

            }
            catch
            {
                throw;
            }
           
        }
    }
}
