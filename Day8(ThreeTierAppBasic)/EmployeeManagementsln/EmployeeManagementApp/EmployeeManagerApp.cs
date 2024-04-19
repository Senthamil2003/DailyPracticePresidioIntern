using EmployeeManagementBLLibrary;
using EmployeeManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp
{
    internal class EmployeeManager
    {
        EmployeeBL employeeBL = new EmployeeBL();
        void AddEmployee()
        {


            try
            {
                Console.WriteLine("Pleae enter the employee name");
                string name = Console.ReadLine() ?? "";
                Employee employee = new Employee() { Name = name };
                int id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the employee for you and the Id is " + id);
                Console.WriteLine("Pleae enter the employee name");
                name = Console.ReadLine() ?? "";
               
                employee = new Employee() { Name = name};
                id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the employee for you and the Id is " + id);
            }
            catch (DuplicateEmployeeNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        void RetriveAllEmployee()
        {
            try
            {
                Console.WriteLine("Retrive All");
                List<Employee> data = employeeBL.GetEmployeeList();
                Console.WriteLine(data.Count);
                foreach (Employee employee in data)
                {
                    Console.WriteLine(employee.ToString());
                }

            }
            catch (NullEmployeeValueException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        void RetriveById()
        {
            try
            {
                Console.WriteLine("Enter the id for the employee");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(employeeBL.GetEmployeeById(id).ToString());
            }
            catch (NullEmployeeValueException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    
        void RetriveByName()
        {
            try
            {
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine() ?? "";
                Console.WriteLine(employeeBL.GetEmployeeByName(name).ToString());
            }
            catch (NullEmployeeValueException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        void UpdateEmployee()
        {
            try
            {
                Console.WriteLine("Enter Name");
                string OldName = Console.ReadLine() ?? "";
                Console.WriteLine("Enter Name");
                string NewName = Console.ReadLine() ?? "";
                employeeBL.ChangeEmployeeName(OldName, NewName);
                Console.WriteLine(employeeBL.GetEmployeeByName(NewName).ToString());
            }
            catch (NullEmployeeValueException e)
            {
                Console.WriteLine(e.Message);
            }


        }
        static void Main(string[] args)
        {
            EmployeeManager app = new EmployeeManager();
            app.AddEmployee();
            app.RetriveAllEmployee();
            app.RetriveById();
            app.RetriveByName();
            app.UpdateEmployee();
           

        }
    }
}
