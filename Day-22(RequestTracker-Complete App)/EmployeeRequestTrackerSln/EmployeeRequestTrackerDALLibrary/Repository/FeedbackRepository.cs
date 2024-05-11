using RequestTrackerModelLibrary.CustomException;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRequestTrackerDALLibrary;
using Microsoft.EntityFrameworkCore;


namespace EmployeeRequestTrackerDALLibrary.Repository
{
    public class FeedbackRepository : IRepository<int, Feedback>
    {
        public readonly RequestTrackerContext _context;
        public FeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Feedback> Add(Feedback entity)
        {
            _context.Feedbacks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Feedback> Delete(int key)
        {
            try
            {
                Feedback Feedback = await Get(key);
                if (Feedback != null)
                {
                    _context.Remove(Feedback);
                    await _context.SaveChangesAsync();
                    return Feedback;
                }
                throw new NoDataFoundException("No Feedback avaliable for given Id");
            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Feedback> Get(int key)
        {
            Feedback Feedback = await _context.Feedbacks.FirstOrDefaultAsync(e => e.FeedbackId == key);

            if (Feedback != null)
            {
                return Feedback;
            }
            throw new NoDataFoundException("No Feedback avaliable for given Id");

        }

        public virtual async Task<List<Feedback>> GetAll()
        {


            return await _context.Feedbacks.ToListAsync();

        }

        public async Task<Feedback> Update(Feedback entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
