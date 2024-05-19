using EmployeeManagerApi.Context;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApi.Reepository
{
    public class RequestRepository : IReposiroty<int, Request>
    {
        private EmployeeContext _context;

        public RequestRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request item)
        {

            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Request> Delete(int key)
        {
            var Request = await Get(key);
            if (Request != null)
            {
                _context.Remove(Request);
                await _context.SaveChangesAsync();
                return Request;
            }
            throw new Exception("No Request with the given ID");
        }

        public async Task<Request> Get(int key)
        {
            return (await _context.Requests.SingleOrDefaultAsync(u => u.RequestId == key)) ?? throw new Exception("No Request with the given ID");
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return (await _context.Requests.ToListAsync());
        }

        public async Task<Request> Update(Request item)
        {
            var Request = await Get(item.RequestId);
            if (Request != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Request;
            }
            throw new Exception("No Request with the given ID");
        }
    }
}
