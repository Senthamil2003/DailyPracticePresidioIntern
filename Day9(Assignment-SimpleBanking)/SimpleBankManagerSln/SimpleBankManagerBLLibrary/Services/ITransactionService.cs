using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SimpleBankManagerModelLibrary;



namespace SimpleBankManagerBLLibrary.Services
{

    public interface ITransaction
    {
        int AddTransaction(Transaction Transaction);
        Transaction GetTransactionById(int id);
        List<Transaction> GetTransactionList();
    }
}
