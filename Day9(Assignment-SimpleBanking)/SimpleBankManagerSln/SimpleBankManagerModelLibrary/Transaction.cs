using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleBankManagerModelLibrary
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public User Sender { get; set; }

        public User Reciever { get; set; }

        public double Amount { get; set; }  

        public DateTime DateOfTransaction { get; set; } 

        public Transaction()
        {
            Amount = 0;
            DateOfTransaction = DateTime.Now;
            Sender= new User();
            Reciever = new User();
            TransactionId = 0;

        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Transaction otherAccount))
            {
                return false;
            }
            return TransactionId == otherAccount.TransactionId;

        }

        public override string ToString()
        {
            return "Transaction Id" + TransactionId + "\n" +"Transaction Date Time:"+DateOfTransaction+"\n" + "Sender Name " + Sender.Name + "\n" + "RecieverName " + Reciever.Name + "\n" + "Transaction Amount" + Amount;
        }

    }
}
