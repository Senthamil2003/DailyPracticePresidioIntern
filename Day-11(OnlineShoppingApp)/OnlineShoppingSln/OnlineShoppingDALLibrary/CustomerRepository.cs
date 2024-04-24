using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;
namespace OnlineShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override Customer GetByKey(int key)
        {
            Predicate<Customer> check = (p) => p.Id == key;

            var result = items.ToList().Find(check);
            if(result != null)
            {
                return result;  
            }
            throw new NoDataWithGiveIdException("No Customer with given id present");   
            
        }

        public override Customer Update(Customer item)
        {

            Customer customer = GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
                int index = items.IndexOf(customer);
                items[index] = item;
            }
            return customer;

        }

    }
}
