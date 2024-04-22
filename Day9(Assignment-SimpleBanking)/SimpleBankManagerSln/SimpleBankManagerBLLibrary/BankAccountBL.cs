using SimpleBankManagerBLLibrary.CustomExceptions;
using SimpleBankManagerBLLibrary.Services;
using SimpleBankManagerDALLibrary;
using SimpleBankManagerModelLibrary;

namespace SimpleBankManagerBLLibrary
{
    public class BankAccountBL : IBankAccountService
    {
        readonly IRepository<double, BankAccount> _BankAccountRepository;
        public BankAccountBL()
        {
            _BankAccountRepository = new BankAccountRepository();
        }

        public double AddBankAccount(BankAccount BankAccount)
        {
            var result = _BankAccountRepository.Add(BankAccount);

            if (result != null)
            {
                return result.UserId;
            }
            throw new DuplicateValueException("Duplicate User Name found please enter unique user name");
        }

        public BankAccount ChangePassword(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public BankAccount Deposit(double AccountNumber, double DepositAmount)
        {
            var result = GetBankAccountByAccountNumber(AccountNumber);
            if (result != null)
            {
                result.SavingsAmount += DepositAmount;
                return UpdateAccount(result);
            }
            throw new NullValueException("Account");
            
        }

        public BankAccount Withdraw(double AccountNumber, double WithdrawAmount)
        {
            var result = GetBankAccountByAccountNumber(AccountNumber);
            if (result != null)
            {
                if ((result.SavingsAmount) - WithdrawAmount < 0)
                {
                  throw new InsufficientBalanceException(result.SavingsAmount);   
                }
                result.SavingsAmount -= WithdrawAmount;
                return UpdateAccount(result);
            }
            throw new NullValueException("Account");
        }


        public BankAccount GetBankAccountByAccountNumber(double AccountNumber)
        {
            var result = _BankAccountRepository.Get(AccountNumber);
            if (result != null)
            {
                return result;
            }
            throw new NullValueException("No such Account Number Present in database");
        }

        public BankAccount UpdateAccount(BankAccount Account)
        {
            var result= _BankAccountRepository.Update(Account);
            if(result != null)
            {
                return result;
            }
            throw new NullValueException("No such Account Number Present in database");
        }
        


        public List<BankAccount> GetBankAccountList()
        {
            var result = _BankAccountRepository.GetAll();
            if (result != null)
            {
                return result;
            }
            throw new NullValueException("No data available in the BankAccount database");

            
        }

        public BankAccount TransferMoney(double SenderAccountNumber,double RecieverAccountNumber,double Amount)
        {
           
            Withdraw(SenderAccountNumber, Amount);
            BankAccount result= Deposit(RecieverAccountNumber,Amount);
            return result;


        }
        public List<Transaction> GetTransactions(double AccountNumber)
        {
            var result =GetBankAccountByAccountNumber(AccountNumber);
            if(result == null)
            {
                return result.TransactionList;
            }
            throw new NullValueException("No such Account Number Present in database");

        }

        public BankAccount LoginFunctionality(string UserName, string Password)
        {
            List<BankAccount> data = _BankAccountRepository.GetAll();
            if (data != null)
            {
                foreach (BankAccount bankAccount in data)
                {
                    if(bankAccount.UserName == UserName && bankAccount.VerifyPassword(Password))
                    {
                        return bankAccount;
                    }
                }
                throw new AuthenticationFailed("User name Password not match");
            }
            throw new NullValueException("No data available in the BankAccount database");
        }

        public void DataValidation()
        {
            throw new NotImplementedException();

        }
        public void FileStorage()
        {
            throw new NotImplementedException();
        }
     
      
    }
}
