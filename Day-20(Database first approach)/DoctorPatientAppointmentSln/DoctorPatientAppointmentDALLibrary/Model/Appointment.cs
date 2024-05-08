using System;
using System.Collections.Generic;

namespace DoctorPatientAppointmentDALLibrary.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
