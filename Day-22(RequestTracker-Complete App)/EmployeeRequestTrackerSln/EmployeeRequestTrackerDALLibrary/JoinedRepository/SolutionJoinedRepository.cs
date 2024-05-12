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
    public class SolutionJoinedRepository:SolutionRepository
    {
        public SolutionJoinedRepository(RequestTrackerContext context):base(context){ 

        }
        public async override Task<List<Solution>> GetAll()
        {
            return   await _context.Solutions
                    .Include(e => e.Feedbacks)
                    .Include(s=>s.AnsweredEmployee)
                    .ToListAsync();
        }
        public async override Task<Solution> Get(int key)
        {
            Solution Solution = await _context.Solutions.Include(e => e.Feedbacks)
                .Include(e=>e.AnsweredEmployee)
                .FirstOrDefaultAsync(e => e.SolutionId == key);

            if (Solution != null)
            {
                return Solution;
            }
            throw new NoDataFoundException("No Solution avaliable for given Id");
        }
    }
}
