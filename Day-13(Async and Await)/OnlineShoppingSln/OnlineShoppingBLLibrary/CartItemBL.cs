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
        CustomerBL customer;
        ProductBL _product;
        CartBL _cart;   
        static int Maxvalue = 0;
        public CartItemBL()
        {
            _CartItemService = new CartItemRepository();

        }
        public CartItemBL(IRepository<int, CartItem> cartItemService, CustomerBL customer, ProductBL product, CartBL cart)
        {
            _CartItemService = cartItemService;
            this.customer = customer;
            _product = product;
            _cart = cart;
        }

        public async Task<CartItem> AddCartItem(int productId,int Quantity,Customer customer)
        {
            try
            {
                var cart =await _cart.FindCartById(customer.CartId);
                if (cart.CartItems.Count <= 5)
                {

                    CartItem CartItem = new CartItem();
                    var product = await _product.FindProductById(productId);
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

                    var result = await _CartItemService.Add(CartItem);
                    cart.CartItems.Add(result);
                    await _cart.UpdateCart(cart);
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
        public async Task<CartItem> FindCartItemById(int id)
        {
            try
            {
                var result = await _CartItemService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);
            }

        }
        public async Task<CartItem> DeleteCartItem(int cartId,int itemId)
        {
            try
            {

                var result = await _CartItemService.Delete(itemId);
                var cart=await _cart.FindCartById(cartId);
                cart.CartItems.Remove(result);
                await _cart.UpdateCart(cart);
                return result;

            }
            catch
            {
                throw;
            }
        }
        public async Task<List<CartItem>> GetAllCartItem()
        {
            try
            {
                var result =await _CartItemService.GetAll();
                return result;

            }
            catch
            {
                throw;

            }

        }

      
        }
 }

