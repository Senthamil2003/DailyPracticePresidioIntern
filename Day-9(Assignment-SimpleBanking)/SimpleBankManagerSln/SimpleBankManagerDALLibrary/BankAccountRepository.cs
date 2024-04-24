using SimpleBankManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerDALLibrary
{
    public class BankAccountRepository : IRepository<double, BankAccount>
    {
        readonly Dictionary<double, BankAccount> _BankAccounts;
        public BankAccountRepository()
        {
            _BankAccounts = new Dictionary<double, BankAccount>();
        }
        public double GenerateId()
        {

            if (_BankAccounts.Count == 0)
                return 1;
            double id = _BankAccounts.Keys.Max();
            return ++id;
        }
        public BankAccount Add(BankAccount item)
        {
            if (_BankAccounts.ContainsValue(item))
            {
                return null;
            }
            double id = GenerateId();
            if(_BankAccounts.Count==0)
                id += 1000000;
            item.UserId = id;
            item.AccountNumber = id;
            _BankAccounts.Add(id, item);
            return item;
        }

        public BankAccount Delete(double key)
        {
            if (_BankAccounts.ContainsKey(key))
            {
                var BankAccount = _BankAccounts[key];
                _BankAccounts.Remove(key);
                return BankAccount;
            }
            return null;
        }

        public BankAccount? Get(double key)
        {
            
            return _BankAccounts.ContainsKey(key) ? _BankAccounts[key] : null;
        }

        public List<BankAccount> GetAll()
        {
            if (_BankAccounts.Count == 0)
                return null;
            return _BankAccounts.Values.ToList();
        }

        public BankAccount Update(BankAccount item)
        {
            if (_BankAccounts.ContainsKey(item.UserId))
            {
                _BankAccounts[item.UserId] = item;
                return item;
            }
            return null;
        }
    }
}
