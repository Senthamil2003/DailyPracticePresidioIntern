using OnlineShoppingBLLibrary;
using OnlineShoppingDALLibrary;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingUnitTest
{
    public class ProductTest
    {

        CustomerBL _customer;
        CartBL _cartBL;
        CartItemBL _cartItemBL;
        ProductBL _productBL;

        [SetUp]
        public async void Setup()
        {
            IRepository<int, Product> productRepository = new ProductRepository();
            IRepository<int, Customer> customerRepository = new CustomerRepository();
            IRepository<int, Cart> cartRepository = new CartRepository();
            IRepository<int, CartItem> cartItemRepository = new CartItemRepository();
            _productBL = new ProductBL(productRepository);
            _cartBL = new CartBL(cartRepository, _productBL);
            _customer = new CustomerBL(customerRepository, _cartBL);
            _cartItemBL = new CartItemBL(cartItemRepository, _customer, _productBL, _cartBL);
            await _productBL.AddProduct(new Product() { Name = "laptop", Price = 90, Image = "LaptopImg", QuantityInHand = 100 });
           await _productBL.AddProduct(new Product() { Name = "Bicycle", Price = 200, Image = "CycleImg", QuantityInHand = 20 });


        }
        [Test]
        public void AddProduct()
        {
            var result=_productBL.AddProduct(new Product() { Name = "Table", Price = 800, Image = "Img", QuantityInHand = 20 });
            Assert.That(result.Id, Is.EqualTo(3));
            Assert.Pass();
        }
        [Test]
        public void FindProduct() {
            var product= _productBL.FindProductById(1);
            Assert.That(product.Id, Is.EqualTo(1));
            Assert.Pass();
        }
        [Test]
        public  void FailFindProduct() {
            var exception = Assert.Throws<NoDataWithGiveIdException>(async () =>await _productBL.FindProductById(90));
            Assert.Pass();
        }

        [Test]
        public  void ExceptionInFindProduct()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _productBL.FindProductById(90));
            Assert.That(exception.Message, Is.EqualTo("No Product with given id present"));
            Assert.Pass();

        }
        [Test]
        public void  DeleteProduct()
        {
            _productBL.DeleteProduct(1);
             var result=_productBL.GetAllProduct();
            Assert.That(result.Count, Is.EqualTo(1));

        }
        [Test]
        public void FailDeleteProduct()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _productBL.DeleteProduct(100));
            Assert.Pass(); 
        }
        [Test]
        public void ExceptionInDeleteProduct()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _productBL.DeleteProduct(100));
            Assert.That(exception.Message, Is.EqualTo("No Product with given id present"));
            Assert.Pass();

        }
       
    }
}
