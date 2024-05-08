using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary.CustomException
{
     public class DuplicatePatientException : Exception
    {
        string msg;
        public DuplicatePatientException()
        {
            msg = "Patient name already exists";
        }
        public override string Message => msg;
    }
}
