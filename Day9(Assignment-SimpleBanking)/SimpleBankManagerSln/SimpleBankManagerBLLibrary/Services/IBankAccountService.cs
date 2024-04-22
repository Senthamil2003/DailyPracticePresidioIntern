using SimpleBankManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerBLLibrary.Services
{
    public interface IBankAccountService
    {
        double AddBankAccount(BankAccount Account);
        BankAccount GetBankAccountByAccountNumber(double AccountNumber);
        BankAccount LoginFunctionality(string UserName, string Password);
        BankAccount Deposit(double AccountNumber, double DepositAmount);

        BankAccount Withdraw(double AccountNumber, double WithdrawAmount);

        BankAccount ChangePassword(string UserName, string Password);

        BankAccount UpdateAccount(BankAccount Account); 

        List<BankAccount> GetBankAccountList();

        List<Transaction> GetTransactions(double AccountNumber);
    }
}
