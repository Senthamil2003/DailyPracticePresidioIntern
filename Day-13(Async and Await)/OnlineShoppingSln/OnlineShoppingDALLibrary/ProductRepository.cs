using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;

namespace OnlineShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override async Task<Product> Delete(int key)
        {
            Product product = await GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
            Predicate<Product> check = (p) => p.Id == key;

            var result = items.ToList().Find(check);
            if (result != null)
            {
                return result;
            }
            throw new NoDataWithGiveIdException("No Product with given id present");

        }

        public override async Task<Product> Update(Product item)
        {

            Product Product =await GetByKey(item.Id);
            if (Product != null)
            {
                Product = item;
                int index = items.IndexOf(Product);
                items[index] = item;
            }
            return Product;

        }

    }
}

