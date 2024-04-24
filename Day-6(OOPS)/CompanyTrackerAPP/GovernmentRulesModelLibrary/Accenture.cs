using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentRulesModelLibrary
{
    public class Accenture : Employee, IgovernmentRules
    {
        public Accenture(int id,string name,string department,string designation ,double basicSalary,double Experience):base(id,name,department,designation,basicSalary,Experience) { 

        }

        public double EmployeePF()
        {
            double employeepf= (0.12) * BasicSalary;
            BasicSalary = BasicSalary-(0.0367)*BasicSalary;
            return employeepf;
        }

        public double gratuityAmount()
        {
            if (Experience> 20)
            {
                return 3*BasicSalary;
            }
            else if(Experience > 10)
            {
                return 2*BasicSalary;
            }
            else if( Experience >5)
            {
                return 1 * BasicSalary;
            }
            else
            {
                return 0;
            }
        }


        public string LeaVeDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year";
        }
    }
}
