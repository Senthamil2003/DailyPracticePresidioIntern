using ReferenceModel;
using System.Text.RegularExpressions;

namespace Day6Sln
{
    internal class Program
    {
        Employee[] employees = new Employee[5];
        void printOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Add Employee\n2.PrintEmployee\n3.SearchAndPrint\n4.SearchAndUpdate\n5.Delete \nAny other number to return.");
            Console.WriteLine("-------------------------------------------------------------------");
        }
        void AddEmployee(int index)
        {
            if (employees.Length == index + 1)
            {
                Console.WriteLine("No more Space for company");
            }
          
            Employee emp = CreateEmployee();
            emp.Id = index + 100;
            employees[index] = emp;

        }
        Employee CreateEmployee()
        {
            Employee employee = new Employee();
            string type = Console.ReadLine() ?? "";
            if (type == "permanent")
            {
                employee = new PermanentEmployee();

            }
            else
            {
                employee = new ContractEmployee();

            }


            employee.GetEmployeeDetails();
            return employee;

        }
        void EmployeePrinter(Employee employee)
        {

            employee.printEmployee();


        }
        void PrintAllEmployee()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No employee to print");
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    break;
                }
                Company comp= new Company();
                comp.EmployeeClient(employees[i]);
                EmployeePrinter(employees[i]);
            }

        }
        Employee? EmployeeSearcher(int id)
        {
            foreach (Employee emp in employees)
            {
                if (emp == null)
                {
                    return null;
                }
                if (emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }
        void SearchAndPrintEmployeeById(int id)
        {
            Employee? emp = EmployeeSearcher(id);
            if (emp != null)
            {
                EmployeePrinter(emp);
                return;
            }
            Console.WriteLine("Employee is not available");
        }
        void EmployeeUpdate(Employee emp, string newName)
        {
            emp.Name = newName;
            Console.WriteLine("Update Successfully");
            EmployeePrinter(emp);
            Console.WriteLine("---------------------------------------");
        }
        void SearchAndUpdateEmployeeById(int id, string newName)
        {
            Employee? emp = EmployeeSearcher(id);
            if (emp != null)
            {
                EmployeeUpdate(emp, newName);
                return;
            }
            Console.WriteLine("Employee Not available");

        }
        void EmployeeDelete(Employee emp)
        {
            int index = Array.IndexOf(employees, emp);


            for (int i = index; i < employees.Length - 1; i++)
            {
                employees[i] = employees[i + 1];
            }
            employees[employees.Length - 1] = null;



            PrintAllEmployee();
            Console.WriteLine("-------------------------------------------");


        }
        void SearchAndDeleteEmployee(int id)
        {
            Employee? emp = EmployeeSearcher(id);
            if (emp != null)
            {
                EmployeeDelete(emp);
                return;
            }
            Console.WriteLine("Employee Not available");

        }
        int IntChecker()
        {

            int Num;
            while (!int.TryParse(Console.ReadLine(), out Num))
                Console.WriteLine("Enter the valid Id");
            return Num;


        }
        static bool StringValidator(string input, out string name)
        {
            name = "";
            string pattern = @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch && input.Length > 0)
            {
                name = input;
                return true;
            }
            return false;


        }

        string GetEmployeeName()
        {
            Console.WriteLine("Enter name");
            string Name;
            while (!StringValidator(Console.ReadLine() ?? "", out Name))
            {
                Console.WriteLine("Enter the valid name");
            }
            return Name;


        }
        void EmployeeManager()
        {
            int option;

            int index = 0;
            do
            {
                printOption();
                Console.WriteLine("Enter the Option");
                option = IntChecker();
                switch (option)
                {
                    case 1:
                        AddEmployee(index);
                        index++;
                        break;
                    case 2:
                        PrintAllEmployee();
                        break;
                    case 3:
                        Console.WriteLine("Enter the employee Id");
                        int id = IntChecker();
                        SearchAndPrintEmployeeById(id);
                        break;
                    case 4:
                        Console.WriteLine("Enter the employee Id");
                        int id1 = IntChecker();
                        Console.WriteLine("Enter the employee Name");
                        string name = GetEmployeeName();
                        SearchAndUpdateEmployeeById(id1, name);
                        break;
                    case 5:
                        Console.WriteLine("Enter the employee Id");
                        int id2 = IntChecker();
                        SearchAndDeleteEmployee(id2);
                        break;
                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);
        }
        static void Main(string[] args)
        {
            Program data = new Program();
            data.EmployeeManager();

        }

    }
}
