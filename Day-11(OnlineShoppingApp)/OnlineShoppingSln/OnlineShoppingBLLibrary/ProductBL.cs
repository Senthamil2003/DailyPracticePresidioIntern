using OnlineShoppingDALLibrary;
using OnlineShoppingModelLibrary.CustomException;
using OnlineShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingBLLibrary
{
    public class ProductBL
    {
        readonly IRepository<int, Product> _ProductService;
        static int Maxvalue = 0;
        public ProductBL()
        {
            _ProductService = new ProductRepository();

        }
        public Product AddProduct(Product Product)
        {
            try
            {
                Product.Id = ++Maxvalue;
                var result = _ProductService.Add(Product);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);
            }

        }
        public Product FindProductById(int id)
        {
            try
            {
                var result = _ProductService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public Product DeleteProduct(int id)
        {
            try
            {
                var result = _ProductService.Delete(id);
                return result;

            }
            catch
            {
                throw;
            }
        }
        public List<Product> GetAllProduct()
        {
            try
            {
                var result = _ProductService.GetAll();
                return result;

            }
            catch
            {
                throw;

            }

        }

        public Product ChangePrize(int ProductId, double NewPrize)
        {
            try
            {
                var result = FindProductById(ProductId);
                result.Price = NewPrize;
                var final = _ProductService.Update(result);
                return final;


            }
            catch
            {
                throw;

            }






        }
    }
}
