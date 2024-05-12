using EmployeeRequestTrackerDALLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerDALLibrary.JoinedRepository
{
    public class FeedbackJoinedRepository:FeedbackRepository
    {
        public readonly RequestTrackerContext _context;
        public FeedbackJoinedRepository(RequestTrackerContext context):base(context) 
        {
            _context = context;
        }
        public async override Task<List<Feedback>> GetAll()
        {
            return await _context.Feedbacks.
                Include(f=>f.Solution)
                .ThenInclude(s=>s.RaisedRequest)
                .ToListAsync();
        }
        public async override Task<Feedback> Get(int key)
        {
            Feedback Feedback = await _context.Feedbacks
                .Include(f => f.Solution)
                .ThenInclude(s => s.RaisedRequest).
                FirstOrDefaultAsync(e => e.FeedbackId == key);

            if (Feedback != null)
            {
                return Feedback;
            }
            throw new NoDataFoundException("No Feedback avaliable for given Id");
        }
    }
}
