using AtmApplicationApp.Context;
using AtmApplicationApp.CustomException;
using AtmApplicationApp.Interface;
using AtmApplicationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApplicationApp.Repository
{
    public class AccountRepository : IRepository<long, Account>
    {
        private readonly AtmContext _context;


        public AccountRepository(AtmContext context)
        {
            _context = context;
        }


        public async Task<Account> Add(Account item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Account cannot be null");

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while adding the Account. " + ex);
            }
        }
        public async Task<Account> Get(long key)
        {
            try
            {
                return await _context.Accounts.SingleOrDefaultAsync(a => a.AccountNumber == key)
                    ?? throw new NoCustomerFoundException($"No Account found with given Account Number {key}");
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error Occur while fetching data from Account. " + ex);
            }
        }

        public async Task<Account> Delete(long key)
        {
            try
            {
                var account = await Get(key);
                _context.Remove(account);
                await _context.SaveChangesAsync();
                return account;
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





        public async Task<IEnumerable<Account>> Get()
        {
            try
            {
                return await _context.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while fetching the Customer. " + ex);
            }
        }


        public async Task<Account> Update(Account item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Account cannot be null");

            try
            {
                var Account = await Get(item.AccountNumber);
                _context.Entry(Account).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return Account;
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while updating the Account. " + ex);
            }
        }
    }
        
}
