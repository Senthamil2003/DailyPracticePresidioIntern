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

        public BankAccount Sender { get; set; }

        public BankAccount Reciever { get; set; }

        public double Amount { get; set; }  

        public DateTime DateOfTransaction { get; set; } 

        public string TransferType { get; set; }    

        public Transaction(BankAccount sender, BankAccount reciever, double amount, DateTime dateOfTransaction,string type)
        {
           
            Sender = sender;
            Reciever = reciever;
            Amount = amount;
            DateOfTransaction = dateOfTransaction;
            TransferType = type;
        }

        public Transaction()
        {
            TransferType =string.Empty;
            Amount = 0;
            DateOfTransaction = DateTime.Now;
            Sender= new BankAccount();
            Reciever = new BankAccount();
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
            return "Transaction Id" + TransactionId + "\n" +"Transfer Type: "+TransferType+"\n"+"Transaction Date Time:"+DateOfTransaction+"\n" + "Sender Name " + Sender.Name + "\n" + "RecieverName " + Reciever.Name + "\n" + "Transaction Amount" + Amount;
        }

    }
}
