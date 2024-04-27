using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;
namespace OnlineShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
          
        public override async Task<CartItem> Delete(int key)
        {
            CartItem CartItem = await GetByKey(key);
            if (CartItem != null)
            {
                 items.Remove(CartItem);
            }
            return CartItem;
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            Predicate<CartItem> check = (p) => p.CartId == key;

            var result = items.ToList().Find(check);
            if (result != null)
            {
                return result;
            }
            throw new NoDataWithGiveIdException("No Customer with given id present");

        }

        public override async Task<CartItem> Update(CartItem item)
        {

            CartItem cartItem = await GetByKey(item.CartId);
            if (cartItem != null)
            {
                cartItem = item;
                int index = items.IndexOf(cartItem);
                items[index] = item;
            }
            return cartItem;

        }

    }
}
