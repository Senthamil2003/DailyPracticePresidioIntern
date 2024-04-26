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
    public class CartBL
    {
        readonly IRepository<int, Cart> _CartService;
        static int Maxvalue = 0;
        public CartBL()
        {
            _CartService = new CartRepository();

        }

        public Cart AddCart(Cart Cart)
        {
            try
            {  
                Cart.Id = ++Maxvalue;
                var result = _CartService.Add(Cart);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);
            }

        }
        public Cart FindCartById(int id)
        {
            try
            {
                var result = _CartService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public double Checkout(int customerId, CustomerBL _customer,ProductBL _product)
        {
            try
            {
                var result = _customer.FindCustomerById(customerId);
                var cart = FindCartById(result.CartId);

                var cartItems = cart.CartItems;
                double sum = 0;

                foreach (CartItem cartItem in cartItems)
                {
                    Product product = _product.FindProductById(cartItem.Product.Id);
                    if (product.QuantityInHand - cartItem.Quantity > 0)
                    {
                        product.QuantityInHand -= cartItem.Quantity;
                        _product.UpdateProductQuantity(product);
                        sum += (cartItem.Quantity * cartItem.Price) + cartItem.Quantity * cartItem.DeliveryCharge;

                    }
                    else
                    {
                        throw new BoundryLimiExceedException("Product quantity not in hand");
                    }

                }

                cart.CartItems.Clear();

                _CartService.Update(cart);





                return sum;

            }
            catch
            {
                throw;
            }
          
        }

        public List<Cart> GetAllCart()
        {
            try
            {
                var result = _CartService.GetAll();
                return result;

            }
            catch
            {
                throw;

            }

        }

        public Cart UpdateCart(Cart cart)
        {
            try
            {
               return  _CartService.Update(cart);


            }
            catch
            {
                throw;

            }

        }
    }
}
