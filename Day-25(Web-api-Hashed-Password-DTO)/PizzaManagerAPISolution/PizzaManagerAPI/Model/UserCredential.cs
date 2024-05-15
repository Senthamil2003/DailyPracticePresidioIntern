using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaManagerAPI.Model
{
    public class UserCredential
    {
        [Key]
        public string UserName { get; set;}
        public byte[] Password { get; set;}
        public byte[] HashedPassword { get; set;}
        public int UserId { get; set;}

        [ForeignKey("UserId")]
        public Customer User { get; set;}
    }
}
