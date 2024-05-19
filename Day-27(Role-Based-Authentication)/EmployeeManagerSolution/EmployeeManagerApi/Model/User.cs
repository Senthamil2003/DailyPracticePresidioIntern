using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerApi.Model
{
    public class User
    {
        [Key]
        public int EmployeeId { get; set; }    
        public byte[] Password { get; set; }
        public byte[] PaswordHash { get; set; }
        public string Status { get; set; } = "Dissable";
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
