using EmployeeManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALLibrary
{
    public class EmployeeRepository:IRepository<int ,Employee>
    {
        readonly Dictionary<int, Employee> _Employees;
        public EmployeeRepository()
        {
            _Employees = new Dictionary<int, Employee>();
        }
        int GenerateId()
        {

            if (_Employees.Count == 0)
                return 1;
            int id = _Employees.Keys.Max();
            return ++id;
        }
        public Employee Add(Employee item)
        {
            if (_Employees.ContainsValue(item))
            {
                return null;
            }
            int id = GenerateId();
            item.Id = id;
            _Employees.Add(id, item);
            return item;
        }

        public Employee Delete(int key)
        {
            if (_Employees.ContainsKey(key))
            {
                var Employee = _Employees[key];
                _Employees.Remove(key);
                return Employee;
            }
            return null;
        }

        public Employee? Get(int key)
        {
            return _Employees.ContainsKey(key) ? _Employees[key] : null;
        }

        public List<Employee> GetAll()
        {
            if (_Employees.Count == 0)
                return null;
            return _Employees.Values.ToList();
        }

        public Employee Update(Employee item)
        {
            if (_Employees.ContainsKey(item.Id))
            {
                _Employees[item.Id] = item;
                return item;
            }
            return null;
        }

    }
}
