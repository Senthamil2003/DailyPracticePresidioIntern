using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingModelLibrary;
using OnlineShoppingModelLibrary.CustomException;

namespace OnlineShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
        string value="";
      
        
        public AbstractRepository() {
            if (typeof(T) == typeof(Customer))
                value = "Customer";
            else if (typeof(T) == typeof(Cart))
                value = "Cart";
            else if (typeof(T) == typeof(CartItem))
                value = "Cart Item";
            else if (typeof(T) == typeof(Product))
                value = "Product";
        }
        public  T Add(T item)
        {
            if (items.Contains(item))
            {
                throw new DuplicateValueFoundException($"Duplicate Value Found in {value} databse");
            }
            
            items.Add(item);
            return item;
        }
        public List<T> GetAll()
        {
            if(items.Count == 0)
            {
                throw new DatabaseEmptyException($"The {value} database is Empty");
            }
            return items;
        }

        public abstract T Delete(K key);



        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}
