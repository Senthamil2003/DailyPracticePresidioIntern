using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerBLLibrary.CustomExceptions
{
    public class DuplicateValueException:Exception
    {
        string NewMessage;
        public DuplicateValueException(string value) {
            NewMessage ="Duplicate " + value+ "Value Exist" ;
            
        }
        public override string Message => NewMessage;

    }
}
