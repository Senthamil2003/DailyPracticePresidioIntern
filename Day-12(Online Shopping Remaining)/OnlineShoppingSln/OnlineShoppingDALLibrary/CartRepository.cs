using OnlineShoppingModelLibrary.CustomException;
using OnlineShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            Predicate<Cart> check = (p) => p.Id == key;

            var result = items.ToList().Find(check);
            if (result != null)
            {
                return result;
            }
            throw new NoDataWithGiveIdException("No Cart with given id present");

        }

        public override Cart Update(Cart item)
        {

            Cart cart = GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
                int index = items.IndexOf(cart);
                items[index] = item;
            }
            return cart;

        }

        

    }
}


