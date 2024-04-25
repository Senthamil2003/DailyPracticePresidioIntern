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
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            Predicate<Product> check = (p) => p.Id == key;

            var result = items.ToList().Find(check);
            if (result != null)
            {
                return result;
            }
            throw new NoDataWithGiveIdException("No Product with given id present");

        }

        public override Product Update(Product item)
        {

            Product Product = GetByKey(item.Id);
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

