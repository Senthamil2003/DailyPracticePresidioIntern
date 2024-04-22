using EmployeeManagementBLLibrary.CustomExceptionHandler;
using EmployeeManagementDALLibrary;
using EmployeeManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly EmployeeRepository _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeNameException();
        }

        public Employee ChangeEmployeeName(string employeeOldName, string employeeNewName)
        {
            var result = GetEmployeeByName(employeeOldName);
            if (result != null)
            {
                result.Name = employeeNewName;
                _employeeRepository.Update(result);
                return result;
            }
            throw new NullEmployeeValueException();


        }

        public Employee GetEmployeeById(int id)
        {
            var result = _employeeRepository.Get(id);
            if (result != null)
            {
                return _employeeRepository.Get(id);
            }
            throw new NullEmployeeValueException();


        }

        public Employee GetEmployeeByName(string employeeName)
        {
            List<Employee> employee = _employeeRepository.GetAll();

            foreach (Employee value in employee)
            {
                if (value.Name == employeeName)
                {
                    return value;
                }

            }
            throw new NullEmployeeValueException();

        }

       
        public List<Employee> GetEmployeeList()
        {
            var result = _employeeRepository.GetAll();
            if (result != null)
            {
                return result;
            }

            throw new NullEmployeeValueException();
        }
    }
}
