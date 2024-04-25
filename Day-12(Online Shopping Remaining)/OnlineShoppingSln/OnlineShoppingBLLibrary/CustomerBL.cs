using OnlineShoppingDALLibrary;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;

namespace OnlineShoppingBLLibrary
{
    public class CustomerBL
    {
        readonly IRepository<int, Customer> _customerService;
        static int Maxvalue = 0;
        public CustomerBL()
        {
            _customerService=new CustomerRepository();

        }
        public Customer AddCustomer(Customer customer,CartBL _cart)
        {
            try
            {
                Cart cart = new Cart();
                customer.Id = ++Maxvalue;
                cart.CustomerId = customer.Id;
                _cart.AddCart(cart);
                customer.CartId=cart.Id;
                var result = _customerService.Add(customer);
                return result;

            }
            catch
            {
                throw;
            }

        }
        public Customer FindCustomerById(int id)
        {
            try
            {
                var result=_customerService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public Customer DeleteCustomer(int id )
        {
            try
            {
                var result = _customerService.Delete(id);
                return result;

            }
            catch
            {
                throw;
            }
        }
        public List<Customer> GetAllCustomer()
        {
            try
            {
                var result = _customerService.GetAll();
                return result;

            }
            catch { 
                throw;
               
            }

        }

        public Customer ChangeUserName(int CustomerId,string NewName)
        {
            try
            {
                var result = FindCustomerById(CustomerId);
                result.Name = NewName;
                var final = _customerService.Update(result);
                return final;
                

            }
            catch
            {
                throw;

            }

        }
        public List<CartItem> GetAllCart(int customerId,CartBL c_cart)
        {
           
         var customer = FindCustomerById(customerId);
         var result = c_cart.FindCartById(customer.CartId);
            if (result.CartItems.Count == 0)
            {
                throw new DatabaseEmptyException("No cart Item Available");
            }
           return result.CartItems;
        }
    }
   
}
