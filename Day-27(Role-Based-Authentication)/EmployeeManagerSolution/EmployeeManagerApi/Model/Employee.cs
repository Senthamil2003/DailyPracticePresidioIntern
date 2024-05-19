using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerApi.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string  Name { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public string Role { get; set; }
        public ICollection<Request> RaisedRequest { get; set; } 
    }
}
