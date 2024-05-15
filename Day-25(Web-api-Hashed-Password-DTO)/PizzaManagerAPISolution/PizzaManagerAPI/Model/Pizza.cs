using System.ComponentModel.DataAnnotations;

namespace PizzaManagerAPI.Model
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; } 
        public string PizzaName { get; set; }
        public int Price { get; set;}
        public int Quantity { get; set;}
        public string? Size { get; set;}

    }
}
