using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceModel
{
    public class ContractEmployee:Employee
    {
        int Wage;
        public ContractEmployee() {
            Type = "Contract";
            Wage = 0;
            
        }
        public override void GetEmployeeDetails()
        {
            base.GetEmployeeDetails();
            Console.WriteLine("Enter wage");
            Wage=Convert.ToInt32(Console.ReadLine());
            CalculateSalary();


        }
        public override void printEmployee()
        {
            base.printEmployee();
            Console.WriteLine($"Employee Salary{Wage}");
            Console.WriteLine($"Employee Salary{Salary}");
            Console.WriteLine($"Employee Type{Type}");
        }
        void CalculateSalary()
        {
            Salary = Wage * 30;
        }

    }
}
