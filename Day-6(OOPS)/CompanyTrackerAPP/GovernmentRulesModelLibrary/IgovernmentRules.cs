using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentRulesModelLibrary
{
    public interface IgovernmentRules
    {
        public double EmployeePF();
        public string LeaVeDetails();
        public double gratuityAmount();
    }
}
