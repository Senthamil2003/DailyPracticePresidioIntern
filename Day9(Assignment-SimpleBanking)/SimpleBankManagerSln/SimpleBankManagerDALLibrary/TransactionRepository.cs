using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankManagerModelLibrary;


namespace SimpleBankManagerDALLibrary
{
    public class TransactionRepository : IRepository<int, Transaction>
    {
        readonly Dictionary<int, Transaction> _Transactions;
        public TransactionRepository()
        {
            _Transactions = new Dictionary<int, Transaction>();
        }
        public int GenerateId()
        {

            if (_Transactions.Count == 0)
                return 1;
            int id = _Transactions.Keys.Max();
            return ++id;
        }
        public Transaction Add(Transaction item)
        {
            if (_Transactions.ContainsValue(item))
            {
                return null;
            }
            int id = GenerateId();
            item.TransactionId = id;
            _Transactions.Add(id, item);
            return item;
        }

        public Transaction Delete(int key)
        {
            if (_Transactions.ContainsKey(key))
            {
                var Transaction = _Transactions[key];
                _Transactions.Remove(key);
                return Transaction;
            }
            return null;
        }

        public Transaction? Get(int key)
        {
            return _Transactions.ContainsKey(key) ? _Transactions[key] : null;
        }

        public List<Transaction> GetAll()
        {
            if (_Transactions.Count == 0)
                return null;
            return _Transactions.Values.ToList();
        }

        public Transaction Update(Transaction item)
        {
            if (_Transactions.ContainsKey(item.TransactionId))
            {
                _Transactions[item.TransactionId] = item;
                return item;
            }
            return null;
        }
    }
}
