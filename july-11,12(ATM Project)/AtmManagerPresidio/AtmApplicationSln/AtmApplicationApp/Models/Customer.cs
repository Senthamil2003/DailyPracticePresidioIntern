using System.ComponentModel.DataAnnotations;

namespace AtmApplicationApp.Models
{
    public class Customer
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
