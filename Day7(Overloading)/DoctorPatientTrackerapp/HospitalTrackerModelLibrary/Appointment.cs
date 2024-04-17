using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerModelLibrary
{
    public class Appointment
    {
      
            public int AppointmentId { get; set; } = 0;
            public Doctor? doctor { get; set; }
            public Patient? patient { get; set; }

            public DateTime Date { get; set; }
        
    }
}
