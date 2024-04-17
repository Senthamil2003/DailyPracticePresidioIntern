using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerModelLibrary
{
    public class Patient:Person
    {
        public string Disease { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            return Name.Equals((obj as Patient)?.Name);
        }

        
    }
}
