using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLLibrary
{
    public class NullDepartmentValueException : Exception
    {
        string msg;
        public NullDepartmentValueException()
        {
            msg = "No values Found"; // Assign the value to the class-level variable
        }
        public override string Message => msg;
    }
}
