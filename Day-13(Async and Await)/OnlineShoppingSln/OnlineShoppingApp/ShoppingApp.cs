﻿using OnlineShoppingBLLibrary;
using OnlineShoppingDALLibrary;
using OnlineShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp
{
    
    public class ShoppingApp
    {
        CustomerBL _customer;
        CartBL _cartBL;
        CartItemBL _cartItemBL;
        ProductBL _productBL;
        public ShoppingApp()
        {
            IRepository<int, Product> productRepository = new ProductRepository();
            IRepository<int, Customer> customerRepository = new CustomerRepository();
            IRepository<int, Cart> cartRepository = new CartRepository();
            IRepository<int, CartItem> cartItemRepository = new CartItemRepository();
            _productBL = new ProductBL(productRepository);
            _cartBL = new CartBL(cartRepository,_productBL);
            _customer = new CustomerBL(customerRepository,_cartBL);
            _cartItemBL = new CartItemBL(cartItemRepository,_customer,_productBL,_cartBL);

        }
       async void AddProduct()
        {
            try
            {
                await _productBL.AddProduct(new Product() { Name = "laptop", Price = 90, Image = "LaptopImg", QuantityInHand = 100 });
               await _productBL.AddProduct(new Product() { Name = "Bicycle", Price = 200, Image = "CycleImg", QuantityInHand = 20 });
               await _productBL.AddProduct(new Product() { Name = "Ps5", Price = 90900, Image = "PS%", QuantityInHand = 23 });
               await _productBL.AddProduct(new Product() { Name = "Table", Price = 800, Image = "Img", QuantityInHand = 20 });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        void PrintMainOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Show Product\n2.Add to cart\n3.Get All Cart\n4.Delete cartitem\n5.Checkout and purchase\nAny other number to Logout.");
            Console.WriteLine("-------------------------------------------------------------------");
        }
        public async Task<Customer> AddCustomer()
        {
            try
            {
                Console.WriteLine("Enter the name");
                string Name = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the Mobile Number");
                string Mobie = Console.ReadLine();
                Console.WriteLine("Enter the Age");
                int Age = Convert.ToInt32(Console.ReadLine());

                Customer customer = new Customer()
                {
                    Name = Name,
                    Phone = Mobie,
                    Age = Age
                };
                return await _customer.AddCustomer(customer);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
               
            }
          
          
        }
       public async void ShowProduct()
        {

            Console.WriteLine("------------------------------------");
            foreach (Product item in await _productBL.GetAllProduct())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("-------------------------------------");
            }
        }
        async void AddItem(Customer customer)
        {
            try
            {

                Console.WriteLine("------------------------------------");
                foreach (Product item in await _productBL.GetAllProduct())
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("-------------------------------------");

                }
               
                Console.WriteLine("Enter the Product Id");
                int ProductId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Quantity");
                int Quantity = Convert.ToInt32(Console.ReadLine());
               await _cartItemBL.AddCartItem(ProductId, Quantity, customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }
       async void GetAllCart(Customer customer )
        {
            try
            {
                Console.WriteLine("------------------------------------------");

                foreach (CartItem item in await _customer.GetAllCart(customer.Id))
                {

                    Console.WriteLine(item.ToString());
                    Console.WriteLine("----------------------------------");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        async void Checkout(Customer customer)
        {
            try
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Total Amount T0 Pay  $"+await _cartBL.Checkout(customer.Id));
                Console.WriteLine("----------------------");
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            }
           
        }
        async void DeleteItem(Customer customer)
        {

            try
            {
                GetAllCart(customer);
                Console.WriteLine("Enter the Cart Id");
                int ProductId = Convert.ToInt32(Console.ReadLine());
               await _cartItemBL.DeleteCartItem(customer.CartId, ProductId);
                Console.WriteLine("Deleted Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
        void ShopManager(Customer customer)
        {
            int option;
            do
            {
                PrintMainOption();
                Console.WriteLine("Enter the Option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ShowProduct();
                        break;
                    case 2:
                        AddItem(customer);
                        break;
                    case 3:
                        GetAllCart(customer);
                        break;
                    case 4:
                        DeleteItem(customer);
                        break;
                    case 5:
                        Checkout(customer);
                        break;
                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);
        }

        void PrintOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Add Customer\n2.Admin\n3.Get All Account\nAny Key to exit");
            Console.WriteLine("-------------------------------------------------------------------");
        }
       async void ShopManager()
        {
            int option;
            do
            {
                PrintOption();
                Console.WriteLine("Enter the Option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var result =await AddCustomer();
                        if (result != null)
                        {
                            ShopManager(result);
                        }
                        break;
                    case 2:
                        
                        break;
                    //case 3:
                    //    GetAllAcccount();
                    //    break;


                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);
        }
        static void Main(string[] args)
        {
            ShoppingApp p = new ShoppingApp();
            p.AddProduct();
            p.ShopManager();

        }
    }

}
