using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmApplicationApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionDescription { get; set; }

       
        public long AccountNumber { get; set; }

        [ForeignKey("AccountNumber")]
        
        public Account Account { get; set; }

    }
}
