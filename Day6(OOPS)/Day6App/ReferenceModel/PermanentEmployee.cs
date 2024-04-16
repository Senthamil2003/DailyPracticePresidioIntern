using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceModel
{
    public class PermanentEmployee:Employee
    {
        public PermanentEmployee()
        {
            Type = "PermanentEmployee";
        }
        public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth)
        {
            Salary = salary;
        }
        public override void GetEmployeeDetails()
        {
            base.GetEmployeeDetails();
            Console.WriteLine("Enter Permanent Salary");
            Salary =Convert.ToInt32(Console.ReadLine());
        }

        public override void printEmployee()
        {
            base.printEmployee();
            Console.WriteLine($"Employee Salary{Salary}");
            Console.WriteLine($"Employee Type{Type}");
        }
    }
}
