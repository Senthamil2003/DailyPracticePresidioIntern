using RequestTrackerModelLibrary.CustomException;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRequestTrackerDALLibrary;

namespace EmployeeRequestTrackerDALLibrary.Repository
{
    public class RequestRepository : IRepository<int, Request>
    {
        public readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            await Console.Out.WriteLineAsync("inside repo");
            _context.Add(entity);
            await _context.SaveChangesAsync();
            await Console.Out.WriteLineAsync("add successfully");
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            try
            {
                Request Request = await Get(key);
                if (Request != null)
                {
                    _context.Remove(Request);
                    await _context.SaveChangesAsync();
                    return Request;
                }
                throw new NoDataFoundException("No Request avaliable for given Id");
            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Request> Get(int key)
        {
            Request Request = _context.Requests.FirstOrDefault(e => e.RequestNumber == key);
            if (Request != null)
            {
                return Request;
            }
            throw new NoDataFoundException("No Request avaliable for given Id");

        }

        public virtual async Task<List<Request>> GetAll()
        {

            return _context.Requests.ToList();
        }

        public async Task<Request> Update(Request entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
