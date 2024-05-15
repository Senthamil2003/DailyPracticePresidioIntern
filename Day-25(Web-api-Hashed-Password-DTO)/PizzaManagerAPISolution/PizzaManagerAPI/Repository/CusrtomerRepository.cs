using Microsoft.EntityFrameworkCore;
using PizzaManagerAPI.Context;
using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;

namespace PizzaManagerAPI.Repository
{
    public class CustomerRepository : IReposiroty<int, Customer>
    {
        private PizzaManagerContext _context;

        public CustomerRepository(PizzaManagerContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer item)
        {

            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Customer> Delete(int key)
        {
            var Customer = await Get(key);
            if (Customer != null)
            {
                _context.Remove(Customer);
                await _context.SaveChangesAsync();
                return Customer;
            }
            throw new Exception("No Customer with the given ID");
        }

        public async Task<Customer> Get(int key)
        {
            return (await _context.Customers.SingleOrDefaultAsync(u => u.UserId == key)) ?? throw new Exception("No Customer with the given ID");
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return (await _context.Customers.ToListAsync());
        }

        public async Task<Customer> Update(Customer item)
        {
            var Customer = await Get(item.UserId);
            if (Customer != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Customer;
            }
            throw new Exception("No Customer with the given ID");
        }
    }
}
