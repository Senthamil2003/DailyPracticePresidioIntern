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
        ProductBL _ProductBL;
       
        public CartBL()
        {
            _CartService = new CartRepository();

        }
        public CartBL(IRepository<int, Cart> cartService,ProductBL product)
        {
            _CartService = cartService;
            _ProductBL = product;
          
        }

        public async Task<Cart> AddCart(Cart Cart)
        {
            try
            {  
                
                var result =await _CartService.Add(Cart);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);
            }

        }
        public  async Task<Cart> FindCartById(int id)
        {
            try
            {
                var result = await _CartService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public async Task<double> Checkout(int customerId)
        {
         
     

            var cart = await FindCartById(customerId);

            var cartItems = cart.CartItems;
            double sum = 0;
            int count = 0;
            double delivery=0;
            foreach (CartItem cartItem in cartItems) 
            {
                count++;
                sum += (cartItem.Quantity * cartItem.Price);
                delivery += cartItem.DeliveryCharge * cartItem.Quantity;
                Product product=await _ProductBL.FindProductById(cartItem.Product.Id);
                if(product.QuantityInHand- cartItem.Quantity < 0)
                {
                    throw new BoundryLimiExceedException("The product is out of stock");
                }
                product.QuantityInHand-=cartItem.Quantity;
               await _ProductBL.UpdateProductQuantity(product);
                
            }
            double discountAmount = 0;
            if (count==3  && sum==1500)
            {
                discountAmount = sum * 0.5;
                
            }
            sum = (sum + delivery) - discountAmount;
        

            cart.CartItems.Clear(); 

           await _CartService.Update(cart);
            




            return sum; 
        }

        public async Task<List<Cart>> GetAllCart()
        {
            try
            {
                var result = await _CartService.GetAll();
                return result;

            }
            catch
            {
                throw;

            }

        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            try
            {
               return  await _CartService.Update(cart);


            }
            catch
            {
                throw;

            }

        }
    }
}
