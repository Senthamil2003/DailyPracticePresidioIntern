using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;

namespace EmployeeRequestTrackerBLLibrary
{
    public class EmployeeBl : EmployeeService
    {
        readonly IRepository<int, Employee> _Employeerepo;
        public EmployeeBl() {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _Employeerepo = repo;
        }

        public async Task<List<Employee>> GetAllEmploye()
        {
            Console.WriteLine("inside bl");
         
            return  await _Employeerepo.GetAll();
        }

        public async Task<bool> Login(string name,string password)
        {
            List<Employee> employees =await _Employeerepo.GetAll();
           Employee employee= employees.FirstOrDefault(e => e.Name == name && e.PasswordCheck(password));
           if (employee == null)
            {
                return false;
            }
           return true;

            
        }

        public Task<Employee> Register(Employee employee)
        {
           
            return  _Employeerepo.Add(employee);
        }
        
    }
}
