using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerModelLibrary
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ContactNumber { get; set; }

        public Person()
        {
            Id = 0;
            Name = string.Empty;
            ContactNumber = 0;
        }
        
    }
}
