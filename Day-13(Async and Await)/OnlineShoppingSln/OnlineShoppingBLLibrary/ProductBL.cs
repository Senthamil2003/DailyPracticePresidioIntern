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
        public ProductBL(IRepository<int ,Product> productBl)
        {
            _ProductService = productBl;

        }
        public async Task<Product> AddProduct(Product Product)
        {
            try
            {
                Product.Id = ++Maxvalue;
                var result = await _ProductService.Add(Product);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);
            }

        }
        public async  Task<Product> FindProductById(int id)
        {
            try
            {
                var result = await _ProductService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                var result = await _ProductService.Delete(id);
                return result;

            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
                var result = await _ProductService.GetAll();
                return result;

            }
            catch
            {
                throw;

            }

        }

        public async Task<Product> UpdateProductQuantity(Product product)
        {
            try
            {
                var final = await _ProductService.Update(product);
                return final;

            }
            catch
            {
                throw;

            }






        }
    }
}
