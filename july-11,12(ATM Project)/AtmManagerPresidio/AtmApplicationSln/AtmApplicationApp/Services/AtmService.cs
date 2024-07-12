using AtmApplicationApp.Interface;
using AtmApplicationApp.Models;
using AtmApplicationApp.Models.DTO;
using AtmApplicationApp.CustomException;

namespace AtmApplicationApp.Services
{
    public class AtmService:IAtmService
    {
        private readonly IRepository<int, Customer> _customerRepo;
        private readonly IRepository<long, Account> _accountRepo;
        private readonly IRepository<long, Card> _cardRepo;
        private readonly IRepository<int, Transaction> _transactionRepo;
        private readonly ITokenService _tokenService;

        public AtmService(
            IRepository<int, Customer> customerRepo,
            IRepository<long, Account> accountRepo,
            IRepository<long, Card> cardRepo,
            IRepository<int, Transaction> transactionRepo,
            ITokenService tokenService
            ) { 
            _customerRepo = customerRepo;
            _accountRepo = accountRepo;
            _cardRepo = cardRepo;
            _transactionRepo = transactionRepo;
            _tokenService = tokenService;
        
        }


      public async Task<ResponseDepositDTO> DepositMoney(long accountNumber,double amount)
        {
            try
            {
                var account = await _accountRepo.Get(accountNumber);
                account.Balance = account.Balance + amount;
                account = await _accountRepo.Update(account);
                var transaction = new Transaction
                {
                    TransactionType = "Credit",
                    TransactionAmount = amount,
                    TransactionDateTime = DateTime.Now,
                    TransactionDescription = "Deposit Money in to Account",
                    AccountNumber = accountNumber,

                };
                transaction = await _transactionRepo.Add(transaction);
                return new ResponseDepositDTO
                {
                    UpdatedBalance = account.Balance,
                };


            }
            catch
            {
                throw;
            }
        }

        public async Task<WithdrawDTO> WithdrawalMoney(long accountNumber,double amount)
        {
            try
            {
                var AccountDetails = await _accountRepo.Get(accountNumber);
                if(AccountDetails.Balance >= amount)
                {
                    AccountDetails.Balance = AccountDetails.Balance - amount;

                    var AccountUpdation = await _accountRepo.Update(AccountDetails);

                    Transaction transaction = new Transaction();
                    transaction.TransactionType = "Debit";
                    transaction.TransactionAmount = amount;
                    transaction.TransactionDateTime = DateTime.Now;
                    transaction.TransactionDescription = "Withdrawal Money from Account";
                    transaction.AccountNumber = accountNumber;

                    var AddTransaction = await _transactionRepo.Add(transaction);

                    WithdrawDTO withdrawDTO = new WithdrawDTO();
                    withdrawDTO.WithdrawalAmount = amount;
                    withdrawDTO.AvailableBalance = AccountDetails.Balance;
                    withdrawDTO.WithdrawalStatus = "Success";

                    return withdrawDTO;
                }
                else
                {
                    throw new Exception("Insufficient Balance Found Exception");
                }
            }
            catch
            {
                throw new Exception("Insufficient Balance Found Exception");

            }
        }




        public async Task<SuccessVerifyDTO> AuthService(VerifyUserDTO verify)
        {
            try
            {
                Card card= (await _cardRepo.Get()).SingleOrDefault(a => a.CardNumber == verify.CardNumber && a.PIN == verify.Pin);
                if(card == null)
                {
                    throw new Exception("No Account Found Exception");
                }
                string token= await _tokenService.GenerateToken(card);
                SuccessVerifyDTO verifyDTO = new SuccessVerifyDTO()
                {
                    Code = 200,
                    Message = "Verified Successully",
                    Token = token
                };
                return verifyDTO;

                

            }
            catch
            {
                throw;

            }
        }
        public async Task<BalanceDTO> CheckBalance(long AccountNumber)
        {
            try
            {
                Account account = await _accountRepo.Get(AccountNumber);
                double balance = account.Balance;
                string Customer = (await _customerRepo.Get(account.UserId)).Name;
                BalanceDTO balanceDTO = new BalanceDTO()
                {
                    AccountNumber = account.AccountNumber,
                    Balance = balance,
                    UserName = Customer
                };
                return balanceDTO;
            }
            catch
            {
                throw ;
            }
           

        }

        public async Task<List<TransactionDto>> GetTransaction(long AccountNumber)
        {
            try
            {
               var result= (await _transactionRepo.Get()).Where(t=>t.AccountNumber==AccountNumber).ToList();
                List<TransactionDto> resultList = new List<TransactionDto>();   
                foreach(var transaction in result)
                {
                    TransactionDto transactionDTO = new TransactionDto()
                    {
                        AccountNumber = transaction.AccountNumber,
                        TransactionAmount = transaction.TransactionAmount,
                        TransactionDateTime = transaction.TransactionDateTime,
                        TransactionDescription = transaction.TransactionDescription,
                        TransactionID = transaction.TransactionID,
                        TransactionType = transaction.TransactionType,
                    };
                    resultList.Add(transactionDTO);
                }
                return resultList;
            }
            catch
            {
                throw;
            }
        }
    }






}

