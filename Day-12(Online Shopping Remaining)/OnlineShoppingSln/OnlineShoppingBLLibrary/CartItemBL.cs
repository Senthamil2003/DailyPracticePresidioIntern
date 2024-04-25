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
        public CartItem AddCartItem(ProductBL _product,int productId,int Quantity,Customer customer,CartBL _cart)
        {
            try
            {
                var cart = _cart.FindCartById(customer.CartId);
                if (cart.CartItems.Count <= 5)
                {

                    CartItem CartItem = new CartItem();
                    var product = _product.FindProductById(productId);
                    if (product != null)
                    {
                        if (product.QuantityInHand - Quantity >= 0)
                        {

                            CartItem.Product = product;
                            if (CartItem.Product.Price < 100)
                            {
                                CartItem.DeliveryCharge = 100;
                            }


                        }
                        else
                        {
                            throw new OutOfStockException("The Product is not available for the given quantity");
                        }
                    }
                    else
                    {
                        throw new NoDataWithGiveIdException("No product with given Id present");

                    }

                    CartItem.Price = CartItem.Product.Price;
                    CartItem.PriceExpiryDate = DateTime.Now.AddHours(24);
                    CartItem.CartId = ++Maxvalue;
                    CartItem.Quantity = Quantity;

                    var result = _CartItemService.Add(CartItem);
                    cart.CartItems.Add(result);
                    _cart.UpdateCart(cart);
                    return result;

                }
                else
                {
                    throw new BoundryLimiExceedException("Cart Limit Exceed");
                }
           




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
        public CartItem DeleteCartItem(int cartId,int itemId,CartBL _cart)
        {
            try
            {

                var result = _CartItemService.Delete(itemId);
                var cart=_cart.FindCartById(cartId);
                cart.CartItems.Remove(result);
                _cart.UpdateCart(cart);
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

