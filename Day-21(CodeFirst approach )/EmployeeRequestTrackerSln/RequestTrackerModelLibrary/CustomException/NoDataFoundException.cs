using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.CustomException
{
     public class NoDataFoundException:Exception
    {
        string message;
        public NoDataFoundException(string value)
        {
            message= value;
        }
        public override string Message => message;
    }
}
