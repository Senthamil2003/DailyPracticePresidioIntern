using RequestTrackerModelLibrary.CustomException;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeRequestTrackerDALLibrary;

namespace EmployeeRequestTrackerDALLibrary.Repository
{
    public class SolutionRepository : IRepository<int, Solution>
    {
        public readonly RequestTrackerContext _context;
        public SolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
      
        public async Task<Solution> Add(Solution entity)
        {
            _context.Solutions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Solution> Delete(int key)
        {
            try
            {
                Solution Solution = await Get(key);
                if (Solution != null)
                {
                    _context.Remove(Solution);
                    await _context.SaveChangesAsync();
                    return Solution;
                }
                throw new NoDataFoundException("No Solution avaliable for given Id");
            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Solution> Get(int key)
        {
            Solution Solution = await _context.Solutions.FirstOrDefaultAsync(e => e.SolutionId == key);

            if (Solution != null)
            {
                return Solution;
            }
            throw new NoDataFoundException("No Solution avaliable for given Id");

        }

        public virtual async Task<List<Solution>> GetAll()
        {


            return await _context.Solutions.ToListAsync();

        }

        public async Task<Solution> Update(Solution entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
