using OnlineShoppingBLLibrary;
using OnlineShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp
{
    internal class ShoppingManager
    {
        CustomerBL _customer;
        CartBL _cartBL;
        CartItemBL _cartItemBL;
        ProductBL _productBL;
        public ShoppingManager()
        {
            _customer = new CustomerBL();
            _cartBL = new CartBL();
            _productBL = new ProductBL();
            _cartItemBL = new CartItemBL();

        }

        void AddProduct()
        {
            try
            {
                _productBL.AddProduct(new Product() { Name = "laptop", Price = 90, Image = "LaptopImg", QuantityInHand = 10 });
                _productBL.AddProduct(new Product() { Name = "Bicycle", Price = 200, Image = "CycleImg", QuantityInHand = 2 });
                _productBL.AddProduct(new Product() { Name = "Ps5", Price = 90900, Image = "PS%", QuantityInHand = 1 });
                _productBL.AddProduct(new Product() { Name = "Table", Price = 800, Image = "Img", QuantityInHand = 20 });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }
        void AddCustomer()
        {
            try
            {
                Customer customer = new Customer()
                {
                    Name = "sentha",
                    Phone = "23432434",
                    Age = 10
                };
                _customer.AddCustomer(customer, _cartBL);

                customer = new Customer()
                {
                    Name = "sena",
                    Phone = "23432434",
                    Age = 12
                };
                _customer.AddCustomer(customer, _cartBL);

                customer = new Customer()
                {
                    Name = "giri",
                    Phone = "23432434",
                    Age = 100
                };
                _customer.AddCustomer(customer, _cartBL);

                List<Customer> list = _customer.GetAllCustomer();
                list.OrderBy(p => p.Age);
                foreach (Customer item in list)
                {
                    Console.WriteLine(item.ToString());

                }
                ////Extension Method 
                //string msg = "Senthamil";
                //Console.WriteLine(msg.Reverse());

              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void AddCartItem()
        {
            try
            {
                Customer customer=_customer.FindCustomerById(1);
                Console.WriteLine("------------------------------------");
                foreach (Product item in _productBL.GetAllProduct())
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("-------------------------------------");
                }
                _cartItemBL.AddCartItem(_productBL, 1, 2, customer, _cartBL);
                _cartItemBL.AddCartItem(_productBL, 2, 2, customer, _cartBL);
                _cartItemBL.AddCartItem(_productBL, 3, 1, customer, _cartBL);
                Console.WriteLine("------------------------------------------");

                foreach (CartItem item in _customer.GetAllCart(customer.Id, _cartBL))
                {

                    Console.WriteLine(item.ToString());
                    Console.WriteLine("----------------------------------");

                }
                Console.WriteLine("=--------------------------------=");
                Console.WriteLine(_cartBL.Checkout(customer.Id, _customer));
               

                //foreach (CartItem item in _customer.GetAllCart(customer.Id, _cartBL))
                //{
                //    Console.WriteLine("0000000000000000000000000");
                //    Console.WriteLine(item.Product.Name);

                //}
                //Console.WriteLine("lppp");
            }
            catch(Exception ex) {
                Console.WriteLine("okokok");
                Console.WriteLine(ex.Message);
            }
            
        }
        void DeleteItem()
        {
            try
            {
                Customer customer = _customer.FindCustomerById(1);
                _cartItemBL.AddCartItem(_productBL, 1, 2, customer, _cartBL);
                _cartItemBL.AddCartItem(_productBL, 2, 2, customer, _cartBL);
                _cartItemBL.AddCartItem(_productBL, 3, 1, customer, _cartBL);
                _cartItemBL.AddCartItem(_productBL, 1, 2, customer, _cartBL);
                _cartItemBL.AddCartItem(_productBL, 2, 2, customer, _cartBL);
           
                Console.WriteLine("------------------------------------------");
                foreach (CartItem item in _customer.GetAllCart(customer.Id, _cartBL))
                {

                    Console.WriteLine(item.ToString());
                    Console.WriteLine("--------------------------------------");

                }

                _cartItemBL.DeleteCartItem(customer.CartId, 5, _cartBL);
                Console.WriteLine("AfterDelete------------------------------------------");
                foreach (CartItem item in _customer.GetAllCart(customer.Id, _cartBL))
                {

                    Console.WriteLine(item.ToString());
                    Console.WriteLine("--------------------------------------");

                }

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        



            
        }
        static void Main(string[] args)
        {
            ShoppingManager p = new ShoppingManager();
            p.AddProduct();
            p.AddCustomer();
            p.AddCartItem();
            p.DeleteItem();
            
        }
    }
}
public static class StringMeth
{

    public static string Reverse(this string msg)
    {
        char [] result= msg.ToCharArray();
        Array.Reverse(result);
        return new string(result);
        

    }
}
