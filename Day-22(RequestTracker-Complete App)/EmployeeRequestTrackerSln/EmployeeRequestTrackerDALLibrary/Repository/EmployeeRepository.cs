using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerDALLibrary.Repository
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        public readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {


            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            try
            {
                Employee employee = await Get(key);
                if (employee != null)
                {
                    _context.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                throw new NoDataFoundException("No Employee avaliable for given Id");
            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Employee> Get(int key)
        {
            Employee employee = await _context.Employees.Include(e => e.RaisedRequests).FirstOrDefaultAsync(e => e.EmployeeId == key);

            if (employee != null)
            {
                return employee;
            }
            throw new NoDataFoundException("No Employee avaliable for given Id");

        }

        public virtual async Task<List<Employee>> GetAll()
        { 

            return await _context.Employees.Include(e => e.RaisedRequests).ToListAsync();

        }

        public async Task<Employee> Update(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
