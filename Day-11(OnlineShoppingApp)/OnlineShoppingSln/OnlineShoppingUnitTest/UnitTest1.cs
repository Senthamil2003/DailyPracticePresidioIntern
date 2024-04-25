using OnlineShoppingBLLibrary;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;
using System.Numerics;
namespace OnlineShoppingUnitTest
{
   
    public class Tests
    {
        CustomerBL _customerBl;
        CartBL _cartBl; 
        
        [SetUp]
        public void Setup()
        {
          _customerBl = new CustomerBL();
          _cartBl = new CartBL();
            Customer customer = new Customer()
            {
                Name = "sentha",
                Phone = "23432434",
                Age = 10
            };
            _customerBl.AddCustomer(customer, _cartBl);

            customer = new Customer()
            {
                Name = "sena",
                Phone = "23432434",
                Age = 12
            };
            _customerBl.AddCustomer(customer, _cartBl);

        }

        [Test]
        public void FindCustomerById()
        {
            var result=_customerBl.FindCustomerById(1);
            Assert.That(result.Name, Is.EqualTo("sentha"));
            Assert.Pass();
        }
        [Test]  
        public void FailFindCustomerById()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _customerBl.FindCustomerById(90));
            Assert.Pass();
        }
        [Test]
        public void ExceptionInFindById()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _customerBl.FindCustomerById(10));
            Assert.That(exception.Message, Is.EqualTo("No Customer with given id present"));
            Assert.Pass();
        }
        [Test]
        public void AddCustomer()
        {
            Customer customer = new Customer()
            {
                Name = "giri",
                Phone = "23432434",
                Age = 10
            };
           var result= _customerBl.AddCustomer(customer,_cartBl);
        Assert.That(result.Name, Is.EqualTo("giri"));
            Assert.Pass();


        }
        [Test]
        public void FailAddCustomer() {
            Customer customer = new Customer()
            {
                Name = "sentha",
                Phone = "23432434",
                Age = 10
            };
            var exception = Assert.Throws<DuplicateValueFoundException>(() => _customerBl.AddCustomer(customer,_cartBl));
            Assert.Pass();
        }
        [Test]
        public void ExceptionInAddCustomer()
        {
            Customer customer = new Customer()
            {
                Name = "sentha",
                Phone = "23432434",
                Age = 10
            };
            var exception = Assert.Throws<DuplicateValueFoundException>(() => _customerBl.AddCustomer(customer, _cartBl));
            Assert.That(exception.Message, Is.EqualTo("Duplicate Value Found in Customer databse"));
            Assert.Pass();

        }

        [Test]
        public void GetAll()
        {
            var result=_customerBl.GetAllCustomer();
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.Pass();  

        }
    }

}