using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerBLLibrary.CustomExceptions
{
    public class InsufficientBalanceException:Exception
    {
        string NewMessage;
        public InsufficientBalanceException(double amount)
        {
            NewMessage = "insufficient Balance \n"+ "Your Balance amount is "+amount;
        }
        public override string Message => NewMessage;
    }
}
