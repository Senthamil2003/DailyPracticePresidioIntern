using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }  
        public string ImageUrls { get; set; }
    }

}
