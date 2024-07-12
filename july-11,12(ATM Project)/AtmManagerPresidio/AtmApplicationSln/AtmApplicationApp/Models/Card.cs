using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmApplicationApp.Models
{
    public class Card
    {
        [Key]
        public long CardNumber { get; set; }

        public int PIN { get; set; }

        public long AccountNumber { get; set; }

        [ForeignKey("AccountNumber")]
        public Account Account { get; set; }
    }
}
