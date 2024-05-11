using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public  class Solution
    {
        [Key]
        public int SolutionId { get; set; }
        public int  RaisedRequestId { get; set; }
        public Request RaisedRequest { get; set; }
        public int AnsweredEmployeeId { get; set; }
        public Employee AnsweredEmployee { get; set; }
        public DateTime PostedDate { get; set; }    
        public bool IsWorked { get; set; }  
        public string? RaiserComment { get; set; }   
        public ICollection<Feedback>? Feedbacks { get; set; }



    }
}
