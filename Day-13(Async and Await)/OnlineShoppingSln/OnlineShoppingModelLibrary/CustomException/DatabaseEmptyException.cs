using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingModelLibrary.CustomException
{
    public class DatabaseEmptyException:Exception
    {
        string message;
        public DatabaseEmptyException(string value)
        {
            message = value;
        }
        public override string Message => message;
    }
}
