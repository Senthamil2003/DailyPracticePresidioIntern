using SimpleBankManagerBLLibrary;
using SimpleBankManagerBLLibrary.Services;
using SimpleBankManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Xml.Linq;

namespace SimpleBankManagerApp
{
    public class SimpleBankManager
    {
        readonly IBankAccountService bankAccountService;
        readonly ITransactionService transactionService;

        public SimpleBankManager()
        {
            bankAccountService = new BankAccountBL();
            transactionService = new TransactionBL();
        }
        void printMainOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Deposit\n2.Withdraw\n3.Amount Transfer\n4.TransactionHistory\n5.Balance \nAny other number to Logout.");
            Console.WriteLine("-------------------------------------------------------------------");
        }
        void Deposit(BankAccount Account)
        {
            try
            {
                Console.WriteLine("Enter the amount to deposit");
                double amount = Convert.ToDouble(Console.ReadLine());
                bankAccountService.Deposit(Account.AccountNumber, amount);
                Console.WriteLine("Amound added successfully!!!!!!!!!!!!!");
                Transaction transaction = new Transaction(null, null, amount, DateTime.Now, "Deposit");
                transactionService.AddTransaction(transaction);
   
                Console.WriteLine("Transaction Added Successfully!!!!!!!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }
        void Withdraw(BankAccount Account)
        {
            try
            {
                Console.WriteLine("Enter the amount to deposit");
                double amount = Convert.ToDouble(Console.ReadLine());
                bankAccountService.Withdraw(Account.AccountNumber, amount);
                Console.WriteLine("Amound added successfully!!!!!!!!!!!!!");
                Transaction transaction = new Transaction(null, null, amount, DateTime.Now, "Withdraw");
                transactionService.AddTransaction(transaction);
                Console.WriteLine("Transaction Added Successfully!!!!!!!!!");
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
          


        }
        void MoneyTransfer(BankAccount Account)
        {
            try
            {
                Console.WriteLine("Enter the AccountNumber Of Sender");
                double SenderNumber = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the amount to Transfer");
                double amount = Convert.ToDouble(Console.ReadLine());
               BankAccount result= bankAccountService.TransferMoney(Account.AccountNumber,SenderNumber, amount);
                Console.WriteLine("Money Transfer Complete!!!!!!!!!!!!");
                Transaction transaction = new Transaction(Account, result, amount, DateTime.Now, "Transfer");
                transactionService.AddTransaction(transaction);
                Console.WriteLine("Transaction Added successfully");



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }
        void GetAllTransaction()
        {
            try
            {
                List<Transaction> data =transactionService.GetTransactionList();
                Console.WriteLine("-----------------------------------------------------------");
                foreach (Transaction item in data)
                {
                    if (item.Sender != null && item.Reciever != null)
                    {
                        Console.WriteLine(item.ToString());

                    }
                    else
                    {
                        Console.WriteLine(item.TransactionId+"\n"+"Transfer Type " +item.TransferType+"\n"+"Amount "+ item.Amount+"\n");
                        
                    }
                    Console.WriteLine("-----------------------------------------------------------");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          

        }
        void Balance(BankAccount Account)
        {
               var result =bankAccountService.GetBankAccountByAccountNumber(Account.AccountNumber);
            Console.WriteLine("Balance"+result.SavingsAmount);
        }
        void MainAccount(BankAccount Account)
        {
            int option;
            do
            {
                printMainOption();
                Console.WriteLine("Enter the Option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Deposit(Account);
                        break;
                    case 2:
                        Withdraw(Account);
                        break;
                    case 3:
                        MoneyTransfer(Account);
                        break;
                    case 4:
                        GetAllTransaction();
                        break;
                    case 5:
                        Balance(Account); 
                        break;
                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);

        }

        void Signup()
        {
            try
            {
                Console.WriteLine("Enter the name");
                string Name = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the Mobile Number");
                double Mobie = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the Date Of Birth");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter the Unique User Name");
                string username = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the Password");
                string password = Console.ReadLine() ?? "";
                BankAccount account1 = new BankAccount(Name, Mobie, dateOfBirth, username, password);
                bankAccountService.AddBankAccount(account1);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        void Login()
        {
            try
            {
                Console.WriteLine("Enter the Unique User Name");
                string username = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the Password");
                string password = Console.ReadLine() ?? "";
                var result = bankAccountService.LoginFunctionality(username, password);
                MainAccount(result);
             

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          

        }
        void printOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Login\n2.Signup\n3.Get All Account\nAny Key to exit");
            Console.WriteLine("-------------------------------------------------------------------");
        }
        void GetAllAcccount()
        {
            try
            {
                List<BankAccount> data = bankAccountService.GetBankAccountList();
                Console.WriteLine("-------------------------------------------");
                foreach (BankAccount item in data)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("--------------------------------------");
                }

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
         
        }
        void BankManager()
        {
            int option;
            do
            {
                printOption();
                Console.WriteLine("Enter the Option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Login();
                        
                        break;
                    case 2:
                        Signup();
                        break;
                    case 3:
                       GetAllAcccount();
                       break;


                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);
        }

        static void Main(string[] args)
        {
            SimpleBankManager bankManager = new SimpleBankManager();
            bankManager.BankManager();
        }
    }
}
