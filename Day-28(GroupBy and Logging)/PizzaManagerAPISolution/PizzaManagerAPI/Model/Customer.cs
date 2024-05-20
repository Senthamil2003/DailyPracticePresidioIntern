using System.ComponentModel.DataAnnotations;

namespace PizzaManagerAPI.Model
{
    public class Customer
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }

    }
}
