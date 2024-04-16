using ReferenceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Sln
{
    internal class Company
    {
        public void EmployeeClient(InternalCompanyWork emp)
        {
            emp.GetOrder();
            emp.GetPayment();

        }


    }
}
