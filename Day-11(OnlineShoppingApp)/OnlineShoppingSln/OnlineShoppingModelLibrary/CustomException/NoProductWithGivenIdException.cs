using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingModelLibrary.CustomException
{
    public class NoProductWithGivenIdException:Exception
    {
        string message;
        public NoProductWithGivenIdException()
        {
            message = "";
        }
        public override string Message => message;
    }
}
