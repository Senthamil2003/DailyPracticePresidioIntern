using NUnit.Framework;
using SimpleBankManagerDALLibrary;
using SimpleBankManagerModelLibrary;
using System;

namespace SimpleBankingTest
{
    public class Tests
    {
        IRepository<double, BankAccount> bank;

        [SetUp]
        public void Setup()
        {
            bank = new BankAccountRepository(); // Initialize your repository here
        }

        [Test]
        public void Test1()
        {
            BankAccount account = new BankAccount("test", 1212213, DateTime.Now, "dswds", "3224324");
            var result = bank.Add(account);
            Assert.AreEqual(1000001, result.UserId);
        }
        [TestCase(1,"ji")]

        public void GetAllTest(int id,string name)
        {
            BankAccount account = new BankAccount("test", 1212213, DateTime.Now, "dswds", "3224324");
            bank.Add(account);
            var result=bank.GetAll();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1000001,account.UserId);
        }
    }
}
