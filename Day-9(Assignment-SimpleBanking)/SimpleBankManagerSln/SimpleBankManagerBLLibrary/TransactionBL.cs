using SimpleBankManagerBLLibrary.CustomExceptions;
using SimpleBankManagerBLLibrary.Services;
using SimpleBankManagerDALLibrary;
using SimpleBankManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerBLLibrary
{
    public class TransactionBL : ITransactionService
    {
        readonly IRepository<int, Transaction> _TransactionRepository;
        public TransactionBL()
        {
            _TransactionRepository = new TransactionRepository();

        }
        public int AddTransaction(Transaction Transaction)
        {
            var result = _TransactionRepository.Add(Transaction);
            if (result != null)
            {
                return Transaction.TransactionId;
            }
            throw new DuplicateValueException("Duplicate transaction Exiat");

        }

        public Transaction GetTransactionById(int id)
        {
           
            var result = _TransactionRepository.Get(id);
            if(result != null)
            {
                return result;
            }
            throw new NullValueException("There is no Transaction Exist");
        }

        public List<Transaction> GetTransactionList()
        {
            List<Transaction> result=_TransactionRepository.GetAll();
            if(result.Count != 0)
            {
                return result;
            }
            throw new NullValueException("No Data in the Transaction Database");
            
        }
    }
}
