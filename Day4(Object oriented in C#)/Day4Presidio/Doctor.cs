using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Day4Presidio
{
    internal class Doctor
    {
        /// <summary>
        /// Get the id and set for the private Id
        /// </summary>
        /// <param name="Id">Should be positive Integer</param>
        public Doctor(int Id) { 
            this.Id=Id;
            Qualification = "";
            Speciality = "";
            Age = 0;
            Name = "";

        }
      
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }

        public string Speciality { get; set; }  

        public void ShowDoctorsDetails()
        {
            Console.WriteLine($"Doctor name {Name}");
            Console.WriteLine($"Doctor's id {Id}");
            Console.WriteLine($"Age of the doctor {Age}");
            Console.WriteLine($"Education qualificaion {Qualification}");
            Console.WriteLine($"Speciality of Doctor {Speciality}");

        }



    }
}
