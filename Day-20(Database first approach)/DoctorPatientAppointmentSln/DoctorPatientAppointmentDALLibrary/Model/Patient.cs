using System;
using System.Collections.Generic;

namespace DoctorPatientAppointmentDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public long? ContactNumber { get; set; }
        public string? Disease { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
