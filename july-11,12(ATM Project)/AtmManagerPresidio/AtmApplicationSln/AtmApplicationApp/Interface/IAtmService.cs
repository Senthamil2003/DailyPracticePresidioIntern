using AtmApplicationApp.Models.DTO;
using System.Transactions;

namespace AtmApplicationApp.Interface
{
    public interface IAtmService
    {
        public Task<ResponseDepositDTO> DepositMoney(long accountNumber, double amount);
        public Task<SuccessVerifyDTO> AuthService(VerifyUserDTO verify);
        public Task<BalanceDTO> CheckBalance(long AccountNumber);
        public Task<WithdrawDTO> WithdrawalMoney(long accountNumber, double amount);
        public Task<List<TransactionDto>> GetTransaction(long AccountNumber);
    }
}
