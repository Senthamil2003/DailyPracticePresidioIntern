using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingModelLibrary.CustomException
{
   
    public class BoundryLimiExceedException:Exception
    {
        string message;

        public BoundryLimiExceedException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
