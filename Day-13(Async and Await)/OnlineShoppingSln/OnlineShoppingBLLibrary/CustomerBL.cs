using OnlineShoppingDALLibrary;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;

namespace OnlineShoppingBLLibrary
{
    public class CustomerBL
    {
        readonly IRepository<int, Customer> _customerService;
        static int Maxvalue = 0;
        CartBL _cart;
        public CustomerBL()
        {
            _customerService=new CustomerRepository();

        }
        public CustomerBL(IRepository<int, Customer> customerService,CartBL cartBL)
        {
            _customerService = customerService;
            _cart = cartBL;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {
                Cart cart = new Cart();
                int id=++Maxvalue;
                customer.Id = id;
                cart.Id = id;
                cart.CustomerId = id;
                customer.CartId = id;
                _cart.AddCart(cart);
                var result =await _customerService.Add(customer);
                return result;

            }
            catch
            {
                throw;
            }

        }
        public async Task<Customer> FindCustomerById(int id)
        {
            try
            {
                var result = await _customerService.GetByKey(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new NoDataWithGiveIdException(ex.Message);

            }

        }
        public async Task<Customer> DeleteCustomer(int id )
        {
            try
            {
                var result = await _customerService.Delete(id);
                return result;

            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            try
            {
                var result = await _customerService.GetAll();
                return result;

            }
            catch { 
                throw;
               
            }

        }

        public async Task<Customer> ChangeUserName(int CustomerId,string NewName)
        {
            try
            {
                var result = await FindCustomerById(CustomerId);
                result.Name = NewName;
                var final = await _customerService.Update(result);
                return final;
                

            }
            catch
            {
                throw;

            }

        }
        public async Task<List<CartItem>> GetAllCart(int customerId)
        {
           
         var customer =await FindCustomerById(customerId);
         var result = await _cart.FindCartById(customer.CartId);
            if (result.CartItems.Count == 0)
            {
                throw new DatabaseEmptyException("No cart Item Available");
            }
           return result.CartItems;
        }
    }
   
}
