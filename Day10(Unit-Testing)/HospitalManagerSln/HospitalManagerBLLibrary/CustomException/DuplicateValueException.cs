using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerBLLibrary.CustomException
{
    public class DuplicateValueException : Exception
    {
        string NewMessage;
        public DuplicateValueException(string value)
        {
            NewMessage = value;

        }
        public override string Message => NewMessage;

    }
}
