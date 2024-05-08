using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorPatientAppointmentModelLibrary
{
    public class Patient:Person
    {
        string Disease {  get; set; }
        public Patient()
        {
            Disease = string.Empty;
        }
        public Patient(string name, string disease) : base(name)
        {
            Disease = disease;
        }
        public override string ToString()
        {

            return "Person Id: "+ Id +"person name: "+ Name+ "\n" +"Disease Name: "+Disease;
            
        }


    }
}
