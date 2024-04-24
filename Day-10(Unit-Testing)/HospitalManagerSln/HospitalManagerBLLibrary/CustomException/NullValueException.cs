using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerBLLibrary.CustomException
{
    public class NullValueException : Exception
    {
        string NewMessage;
        public NullValueException(string value)
        {
            NewMessage = value;
        }
        public override string Message => NewMessage;
    }
}
