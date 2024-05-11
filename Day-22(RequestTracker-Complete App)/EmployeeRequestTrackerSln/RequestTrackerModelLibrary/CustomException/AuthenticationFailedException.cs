using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.BusinessLogic
{
    public class AuthenticationFailedException:Exception
    {
        string message;
        public AuthenticationFailedException(string value) {
            message = value;
        }
        public override string Message => message;
    }
}
