using AtmApplicationApp.Context;
using AtmApplicationApp.CustomException;
using AtmApplicationApp.Interface;
using AtmApplicationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApplicationApp.Repository
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly AtmContext _context;


        public CustomerRepository(AtmContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Customer> Add(Customer item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Customer cannot be null");

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while adding the Customer. " + ex);
            }
        }

        public async Task<Customer> Delete(int key)
        {
            try
            {
                var Customer = await Get(key);
                _context.Remove(Customer);
                await _context.SaveChangesAsync();
                return Customer;
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while deleting the Customer. " + ex);
            }
        }


        public async Task<Customer> Get(int key)
        {
            try
            {
                return await _context.Customers.SingleOrDefaultAsync(u => u.UserId == key)
                    ?? throw new NoCustomerFoundException($"No Customer found with given id {key}");
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error Occur while fetching data from Customer. " + ex);
            }
        }


        public async Task<IEnumerable<Customer>> Get()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while fetching the Customer. " + ex);
            }
        }


        public async Task<Customer> Update(Customer item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Customer cannot be null");

            try
            {
                var Customer = await Get(item.UserId);
                _context.Entry(Customer).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return Customer;
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while updating the Customer. " + ex);
            }
        }
    }
}
