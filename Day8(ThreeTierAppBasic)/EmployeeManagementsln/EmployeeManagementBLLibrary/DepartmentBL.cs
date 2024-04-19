using EmployeeManagementDALLibrary;
using EmployeeManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly DepartmentRepository _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var result=GetDepartmentByName(departmentOldName);
            if (result != null) {
                result.Name = departmentNewName;
                _departmentRepository.Update(result);
                return result;
            }
            throw new NullDepartmentValueException();
            
           
        }

        public Department GetDepartmentById(int id)
        {
            var result= _departmentRepository.Get(id);
            if(result != null)
            {
                return _departmentRepository.Get(id);
            }
            throw new NullDepartmentValueException();
           
           
        }

        public Department GetDepartmentByName(string departmentName)
        {
            List<Department> department = _departmentRepository.GetAll();

            foreach (Department value in department)
            {
                if (value.Name == departmentName)
                {
                    return value;
                }

            }
            throw new NullDepartmentValueException();

        }

        public Department GetDepartmentHeadId(int departmentId)
        {
            List<Department> department = _departmentRepository.GetAll();

            foreach (Department value in department)
            {
                if (value.Department_Head_Id == departmentId)
                {
                    return value;
                }

            }
            throw new NullDepartmentValueException();
        }

        public List<Department> GetDepartmentList()
        {
            var result= _departmentRepository.GetAll();
            if (result != null)
            {
                return result;
            }
                   
             throw new NullDepartmentValueException();
        }
    }
}
