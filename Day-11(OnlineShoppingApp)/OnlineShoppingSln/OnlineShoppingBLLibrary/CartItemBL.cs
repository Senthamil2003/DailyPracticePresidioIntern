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
    public class CartItemBL
    {
        readonly IRepository<int, CartItem> _CartItemService;
        static int Maxvalue = 0;
        public CartItemBL()
        {
            _CartItemService = new CartItemRepository();

        }
        public CartItem AddCartItem(CartItem CartItem)
        {
            try
            {

                if(CartItem.Product.Price <100) {
                    CartItem.DeliveryCharge = 100;
                }
                CartItem.Price = CartItem.Product.Price;
                CartItem.PriceExpiryDate = DateTime.Now.AddHours(24);
                CartItem.CartId = ++Maxvalue;
                var result = _CartItemService.Add(CartItem);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);
            }

        }
        public CartItem FindCartItemById(int id)
        {
            try
            {
                var result = _CartItemService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public CartItem DeleteCartItem(int id)
        {
            try
            {
                var result = _CartItemService.Delete(id);
                return result;

            }
            catch
            {
                throw;
            }
        }
        public List<CartItem> GetAllCartItem()
        {
            try
            {
                var result = _CartItemService.GetAll();
                return result;

            }
            catch
            {
                throw;

            }

        }

      
        }
 }

