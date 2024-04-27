using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingModelLibrary
{
    public class CartItem
    {
        public int CartId { get; set; }//Navigation property
       
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public double DeliveryCharge { get; set; }
        public CartItem()
        {
            CartId = 0;
       
            Product = new Product();
            Quantity = 0;
            Price = 0;
            Discount = 0;
            PriceExpiryDate = DateTime.Today;
            DeliveryCharge = 0;
        }
        public CartItem(Product product, int quantity)
        { 
            Product = product;
            Quantity = quantity;
           
        }
        public override bool Equals(object? obj)
        {
            return this.CartId.Equals((obj as CartItem).CartId);
        }
        public override string ToString()
        {
            return "Id " + CartId + "\n" + "Quantity " + Quantity + "\n" + "Price " + Price + "\n" + "ExperyDate " + PriceExpiryDate;
        }
    }
}
