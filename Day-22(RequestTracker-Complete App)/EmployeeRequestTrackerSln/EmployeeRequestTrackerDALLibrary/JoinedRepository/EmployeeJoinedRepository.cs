using EmployeeRequestTrackerDALLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerDALLibrary.JoinedRepository
{
    public class EmployeeJoinedRepository : EmployeeRepository
    {
        public EmployeeJoinedRepository(RequestTrackerContext context) : base(context)
        {

        }
        public async override Task<List<Employee>> GetAll()
        {

            return await _context.Employees
                    .Include(e => e.RaisedRequests)
                    .Include(e => e.ClosedRequest)
                    .Include(e => e.GivenSolutions)
                    .Include(e => e.GivenFeedbacks)
                    .ToListAsync();

        }
        public override Task<Employee> Get(int key)
        {
            return base.Get(key);
        }

    }
}
