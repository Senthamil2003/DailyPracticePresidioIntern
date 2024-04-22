using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerBLLibrary.CustomExceptions
{
    public class AuthenticationFailed : Exception
    {
        string NewMessage;
        public AuthenticationFailed(string value)
        {
            NewMessage = value;

        }
        public override string Message => NewMessage;

    }
}
