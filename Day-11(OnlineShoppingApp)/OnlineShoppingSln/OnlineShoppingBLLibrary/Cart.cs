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
        public Cart DeleteCart(int id)
        {
            try
            {
                var result = _CartService.Delete(id);
                return result;

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

        //public Cart ChangeUserName(int CartId, string NewName)
        //{
        //    try
        //    {
        //        var result = FindCartById(CartId);
        //        result.Name = NewName;
        //        var final = _CartService.Update(result);
        //        return final;


        //    }
        //    catch
        //    {
        //        throw;

        //    }

        //}
    }
}
