using OnlineShoppingBLLibrary;
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
        ProductBL _productBL;

        [SetUp]
        public void Setup()
        {
            _productBL = new ProductBL();
            _productBL.AddProduct(new Product() { Name = "laptop", Price = 90, Image = "LaptopImg", QuantityInHand = 100 });
            _productBL.AddProduct(new Product() { Name = "Bicycle", Price = 200, Image = "CycleImg", QuantityInHand = 20 });


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
            var product=_productBL.FindProductById(1);
            Assert.That(product.Id, Is.EqualTo(1));
            Assert.Pass();
        }
        [Test]
        public void FailFindProduct() {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _productBL.FindProductById(90));
            Assert.Pass();
        }

        [Test]
        public void ExceptionInFindProduct()
        {
            var exception = Assert.Throws<NoDataWithGiveIdException>(() => _productBL.FindProductById(90));
            Assert.That(exception.Message, Is.EqualTo("No Product with given id present"));
            Assert.Pass();

        }
        
    }
}
