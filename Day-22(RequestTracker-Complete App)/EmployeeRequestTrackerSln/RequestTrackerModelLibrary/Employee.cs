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

        public List<Request> RaisedRequests { get; set; }
        public List<Request> ClosedRequest { get; set; }    
        public List<Solution> GivenSolutions { get; set; }   
        public List<Feedback> GivenFeedbacks { get; set; }

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
