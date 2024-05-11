using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public int SolutionId { get; set; }
        public Solution Solution { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int FeedbackCount { get; set; }

    }
}
