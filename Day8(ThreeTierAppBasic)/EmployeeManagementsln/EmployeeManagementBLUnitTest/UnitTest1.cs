using EmployeeManagementBLLibrary;
using EmployeeManagementDALLibrary;
using EmployeeManagementModelLibrary;

namespace EmployeeManagementBLUnitTest
{
    public class Tests
    {
        IEmployeeService employeeService;
        IRepository<int, Employee> repository;

        //public void Setup()
        //{
        //    repository = new EmployeeRepository();
        //    Employee employee = new Employee(1, "sentha");
        //    repository.Add(employee);
        //    employeeService = new EmployeeBL(repository);
        //}
        [SetUp]
        public void Setup()
        {
            employeeService = new EmployeeBL();

            Employee employee = new Employee(1, "sentha");
            employeeService.AddEmployee(employee);
        
        }

        [Test]
        public void Test1()
        {
            var result = employeeService.GetEmployeeByName("sentha");

            Assert.That(result.Id, Is.EqualTo(1));
            Assert.Pass();
        }
    }
}