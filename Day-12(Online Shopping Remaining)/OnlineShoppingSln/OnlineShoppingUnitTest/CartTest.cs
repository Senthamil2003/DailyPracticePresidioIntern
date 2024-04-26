using OnlineShoppingBLLibrary;
using OnlineShoppingModelLibrary.CustomException;
using OnlineShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingUnitTest
{
    internal class CartTest
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
        public void FindCart()
        {
            var result = _cartBl.FindCartById(1);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.Pass();
        }
        [Test]
        public void FailFindCart()
        {
            
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _cartBl.FindCartById(20));
            Assert.Pass();
         
        }
        [Test]
        public void ExceptionInFindCartById()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _cartBl.FindCartById(20));
            Assert.That(exception.Message, Is.EqualTo("No Cart with given id present"));
            Assert.Pass();
        }
        [Test]
        public void Addcart()
        {
           Customer customer = new Customer()
            {
                Name = "ko",
                Phone = "23432434",
                Age = 12
            };
            var result=_customerBl.AddCustomer(customer, _cartBl);
            var cart=_cartBl.FindCartById(3);
            Assert.That(cart.CustomerId, Is.EqualTo(result.Id));
            Assert.Pass();

        }
     
    }
        
 }

