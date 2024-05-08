using System;
using System.Collections.Generic;

namespace HospitalTrackerDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public long? ContactNumber { get; set; }
        public int? Experience { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
