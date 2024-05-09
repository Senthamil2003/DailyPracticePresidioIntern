using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        public readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context) { 
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
                    _context.SaveChanges();
                    return employee;
                }
                throw new NoDataFoundException("No Employee avaliable for given Id");
            }
            catch 
            {
                throw;
            }
          
            
        }

        public async Task<Employee> Get(int key)
        {
           Employee employee=await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == key);

            if (employee != null)
            {
                return employee;
            }
            throw new NoDataFoundException("No Employee avaliable for given Id");
         
        }

        public async Task<List<Employee>> GetAll()
        {
           

            return  await _context.Employees.ToListAsync();

        }

        public async Task<Employee> Update(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
       
        }
    }
}
