using AtmApplicationApp.Context;
using AtmApplicationApp.CustomException;
using AtmApplicationApp.Interface;
using AtmApplicationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApplicationApp.Repository
{
    public class TransactionRepository : IRepository<int, Transaction>
    {
        private readonly AtmContext _context;


        public TransactionRepository(AtmContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Transaction> Add(Transaction item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Transaction cannot be null");

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while adding the Transaction. " + ex);
            }
        }

        public async Task<Transaction> Delete(int key)
        {
            try
            {
                var Transaction = await Get(key);
                _context.Remove(Transaction);
                await _context.SaveChangesAsync();
                return Transaction;
            }
            catch (NoTransactionFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while deleting the Transaction. " + ex);
            }
        }


        public async Task<Transaction> Get(int key)
        {
            try
            {
                return await _context.Transactions.SingleOrDefaultAsync(u => u.TransactionID == key)
                    ?? throw new NoTransactionFoundException($"No Transaction found with given id {key}");
            }
            catch (NoTransactionFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error Occur while fetching data from Transaction. " + ex);
            }
        }


        public async Task<IEnumerable<Transaction>> Get()
        {
            try
            {
                return await _context.Transactions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while fetching the Transaction. " + ex);
            }
        }


        public async Task<Transaction> Update(Transaction item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Transaction cannot be null");

            try
            {
                var Transaction = await Get(item.TransactionID);
                _context.Entry(Transaction).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return Transaction;
            }
            catch (NoTransactionFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while updating the Transaction. " + ex);
            }
        }
    }
}
