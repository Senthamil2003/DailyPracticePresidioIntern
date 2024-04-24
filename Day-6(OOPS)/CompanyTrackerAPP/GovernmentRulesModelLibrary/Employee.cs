using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentRulesModelLibrary
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Department { get; set; } = string.Empty;  
        public string Designation { get; set; } = string.Empty;
        public double BasicSalary { get; set; }
        public double  Experience { get; set; }

        public Employee() { 
            EmployeeId = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            BasicSalary = 0.0;
            Experience = 0.0;


        }
        public Employee(int empid,string name,string department,string designation ,double basicSalary,double experience)
        {
            EmployeeId = empid;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
            Experience = experience;    
        }

      
    }
}
