using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentModelLibrary
{
    public class Appointment
    {
        public int AppointmentId { get; set; }  
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }  
        public Appointment() {
            AppointmentId = 0;
            Title = string.Empty;
            DateTime = DateTime.MinValue;
            Doctor = new Doctor();
            Patient = new Patient();
        }
        public Appointment(string title, DateTime dateTime, Doctor doctor, Patient patient)
        {
           
            Title = title;
            DateTime = dateTime;
            Doctor = doctor;
            Patient = patient;
        }
        
    }
}
