using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentRulesModelLibrary
{
    public class TCS:Employee,IgovernmentRules
    {
        public TCS(int id, string name, string department, string designation, double basicSalary,double experience) : base(id, name, department, designation, basicSalary,experience)
        {

        }

        public double EmployeePF()
        {
            double employerPf =  (0.12) * BasicSalary;
            double employeePf = (0.12) * BasicSalary;
            BasicSalary = BasicSalary - (0.12) * BasicSalary;
            return employeePf+employerPf;
        }

        public double gratuityAmount()
        {
            return -1;
        }


        public string LeaVeDetails()
        {
            return "2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year";
        }

    }
}
