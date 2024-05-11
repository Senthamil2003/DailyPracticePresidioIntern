using System.ComponentModel.DataAnnotations;

namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<Request> RaisedRequests { get; set; }
        public ICollection<Request> ClosedRequest { get; set; }    
        public ICollection<Solution> GivenSolutions { get; set; }   
        public ICollection<Feedback> GivenFeedbacks { get; set; }

        public override string ToString()
        {
            return EmployeeId + " " + Name + " " + Role;
        }
        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }

    }
}
