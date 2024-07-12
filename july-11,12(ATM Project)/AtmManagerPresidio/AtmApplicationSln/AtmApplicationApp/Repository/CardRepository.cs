using AtmApplicationApp.Context;
using AtmApplicationApp.CustomException;
using AtmApplicationApp.Interface;
using AtmApplicationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApplicationApp.Repository
{
    public class CardRepository : IRepository<long, Card>
    {
        private readonly AtmContext _context;


        public CardRepository(AtmContext context)
        {
            _context = context;
        }


        public async Task<Card> Add(Card item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Card cannot be null");

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while adding the Card. " + ex);
            }
        }
        public async Task<Card> Get(long key)
        {
            try
            {
                return await _context.Cards.SingleOrDefaultAsync(a => a.CardNumber == key)
                    ?? throw new NoCustomerFoundException($"No Card found with given Card Number {key}");
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error Occur while fetching data from Card. " + ex);
            }
        }

        public async Task<Card> Delete(long key)
        {
            try
            {
                var card = await Get(key);
                _context.Remove(card);
                await _context.SaveChangesAsync();
                return card;
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while deleting the Card. " + ex);
            }
        }

        public async Task<IEnumerable<Card>> Get()
        {
            try
            {
                return await _context.Cards.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while fetching the Card. " + ex);
            }
        }


        public async Task<Card> Update(Card item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Card cannot be null");

            try
            {
                var Card = await Get(item.CardNumber);
                _context.Entry(Card).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return Card;
            }
            catch (NoCustomerFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while updating the Card. " + ex);
            }
        }
    }
}
