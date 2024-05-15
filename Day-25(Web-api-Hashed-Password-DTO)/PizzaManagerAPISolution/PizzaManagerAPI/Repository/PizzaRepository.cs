using Microsoft.EntityFrameworkCore;
using PizzaManagerAPI.Context;
using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;

namespace PizzaManagerAPI.Repository
{
    public class PizzaRepository : IReposiroty<int, Pizza>
    {
        private PizzaManagerContext _context;

        public PizzaRepository(PizzaManagerContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {

            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var Pizza = await Get(key);
            if (Pizza != null)
            {
                _context.Remove(Pizza);
                await _context.SaveChangesAsync();
                return Pizza;
            }
            throw new Exception("No Pizza with the given ID");
        }

        public async Task<Pizza> Get(int key)
        {
            return (await _context.Pizzas.SingleOrDefaultAsync(u => u.PizzaId == key)) ?? throw new Exception("No Pizza with the given ID");
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return (await _context.Pizzas.ToListAsync());
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var Pizza = await Get(item.PizzaId);
            if (Pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Pizza;
            }
            throw new Exception("No Pizza with the given ID");
        }
    }
}
