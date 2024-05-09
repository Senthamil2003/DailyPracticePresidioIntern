using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
   public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
       


        public int RequestRaisedBy { get; set; }
        public string RequestStatus { get; set; }   

        [ForeignKey("RequestRaisedBy")]
        public Employee RaisedByEmployee { get; set; }

        public int RequestClosedBy {  get; set; }

        [ForeignKey("RequestClosedBy")]
        public Employee ClosedByEmployee { get; set; }




    }
}
