using OnlineShoppingBLLibrary;
using OnlineShoppingModelLibrary.CustomException;
using OnlineShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingDALLibrary;

namespace OnlineShoppingUnitTest
{
    internal class CartTest
    {

        CustomerBL _customerBl;
        CartBL _cartBl;
        CartItemBL _cartItemBL;
        ProductBL _productBL;

        [SetUp]
        public void Setup()
        {
            IRepository<int, Product> productRepository = new ProductRepository();
            IRepository<int, Customer> customerRepository = new CustomerRepository();
            IRepository<int, Cart> cartRepository = new CartRepository();
            IRepository<int, CartItem> cartItemRepository = new CartItemRepository();
            _productBL = new ProductBL(productRepository);
            _cartBl = new CartBL(cartRepository, _productBL);
            _customerBl = new CustomerBL(customerRepository, _cartBl);
            _cartItemBL = new CartItemBL(cartItemRepository, _customerBl, _productBL, _cartBl);
            Customer customer = new Customer()
            {
                Name = "sentha",
                Phone = "23432434",
                Age = 10
            };
            _customerBl.AddCustomer(customer);

            customer = new Customer()
            {
                Name = "sena",
                Phone = "23432434",
                Age = 12
            };
            _customerBl.AddCustomer(customer);

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
            var result=_customerBl.AddCustomer(customer);
            var cart=_cartBl.FindCartById(3);
            Assert.That(cart.CustomerId, Is.EqualTo(result.Id));
            Assert.Pass();

        }
     
    }
        
 }

