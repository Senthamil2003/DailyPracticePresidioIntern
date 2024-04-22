using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerModelLibrary
{
    public  class BankAccount:User
    {
        public double AccountNumber { get; set; }
        public string UserName { get; set; }

        public double SavingsAmount {  get; set; }
        public List<Transaction> TransactionList { get; set; }

        public BankAccount()
        {
            AccountNumber = 0;
            UserName = string.Empty;
            SavingsAmount = 0;
            TransactionList = new List<Transaction>();

        }
        public BankAccount(string name, double mobile,DateTime dateOfBirth,double accountNumber,string userName,double savingsAmount):base(name,mobile,dateOfBirth)
        {
            AccountNumber=accountNumber;
            UserName=userName;
            SavingsAmount=savingsAmount;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is BankAccount otherAccount))
            {
                return false;
            }
            return UserName == otherAccount.UserName;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "AccountNumber: " + AccountNumber + "\n" + "Unique User Name: " + UserName + "\n" + "Account Holder Name: " + Name + "\n" + "Balance Amount" + SavingsAmount;
        }







    }
}
