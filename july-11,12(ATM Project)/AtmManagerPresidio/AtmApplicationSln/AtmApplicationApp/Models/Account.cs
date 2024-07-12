using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmApplicationApp.Models
{
    public class Account
    {
        [Key]
        public long AccountNumber { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Customer Customer { get; set; }

    }
}
