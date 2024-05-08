using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorPatientAppointmentModelLibrary
{
    public class Doctor:Person
    {
        public List<int> AppointmentId { get; set; }

        public string Specilization { get; set; }

        public Doctor()
        {

            AppointmentId = new List<int>();
            Specilization = "";
        }
        public Doctor(string name, string specilization):base(name) 
        {

            Specilization = specilization;

        }
        public override bool Equals(object? obj)
        {

            return this.Name.Equals((obj as Doctor).Name);
        }
        public override string ToString()
        {
            return "Doctor Id: " + Id + "Doctor name: " + Name + "\n" + "Specialization: " + Specilization;
        }
    }
}
