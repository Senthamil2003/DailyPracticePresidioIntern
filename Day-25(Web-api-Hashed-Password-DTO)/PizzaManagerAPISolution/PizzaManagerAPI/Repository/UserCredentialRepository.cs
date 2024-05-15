using Microsoft.EntityFrameworkCore;
using PizzaManagerAPI.Context;
using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;

namespace PizzaManagerAPI.Repository
{
    public class UserCredentialRepository : IReposiroty<int, UserCredential>
    {
        private PizzaManagerContext _context;

        public UserCredentialRepository(PizzaManagerContext context)
        {
            _context = context;
        }
        public async Task<UserCredential> Add(UserCredential item)
        {

            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserCredential> Delete(int key)
        {
            var UserCredential = await Get(key);
            if (UserCredential != null)
            {
                _context.Remove(UserCredential);
                await _context.SaveChangesAsync();
                return UserCredential;
            }
            throw new Exception("No UserCredential with the given ID");
        }

        public async Task<UserCredential> Get(int key)
        {
            return (await _context.UserCredentials.SingleOrDefaultAsync(u => u.UserId == key)) ?? throw new Exception("No UserCredential with the given ID");
        }

        public async Task<IEnumerable<UserCredential>> Get()
        {
            return (await _context.UserCredentials.ToListAsync());
        }

        public async Task<UserCredential> Update(UserCredential item)
        {
            var UserCredential = await Get(item.UserId);
            if (UserCredential != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return UserCredential;
            }
            throw new Exception("No UserCredential with the given ID");
        }
    }
}
