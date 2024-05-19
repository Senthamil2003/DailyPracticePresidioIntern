using EmployeeManagerApi.Context;
using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApi.Reepository
{
    public class EmployeeRepository : IReposiroty<int, Employee>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context) {
            _context=context;

        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();    

            return item;
            
        }

        public async Task<Employee> Delete(int key)
        {
            try
            {
                Employee employee = await Get(key);
                if(employee != null)
                {
                    _context.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                throw new NoEmployeeFoundException();

            }
            catch
            {
                throw;
            }
            
            
        }

        public async Task<Employee> Get(int key)
        {
            try
            {
                Employee employee = _context.Employees.Include(e=>e.RaisedRequest).FirstOrDefault(e => e.EmployeeId == key);
                if (employee != null)
                {
                    return employee;
                }
                throw new NoEmployeeFoundException();

            }
            catch
            {
                throw;
            }
           

        }

        public async Task<IEnumerable<Employee>> Get()
        {
            try
            {
               IEnumerable<Employee> employees =_context.Employees.Include(e=>e.RaisedRequest);
                if (employees !=null)
                {
                    return  employees;
                }
                throw new  NoEmployeeFoundException();

            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> Update(Employee item)
        {
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();  
                return item;

            }
            catch
            {
                throw;
            }
        }
    }
}
