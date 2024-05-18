using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerApi.Model
{
    public class Request
    {
        public int RequestId { get; set; }
        public string Statement { get; set; }
        public string RequestStatus { get; set; } = "Open";
        public DateTime RaiseDate { get; set; }=DateTime.Now;
        public int EmployeeId {  get; set; }    

        [ForeignKey("EmployeeId")]
        public Employee RaisedByEmployee { get; set; }

    }
}
