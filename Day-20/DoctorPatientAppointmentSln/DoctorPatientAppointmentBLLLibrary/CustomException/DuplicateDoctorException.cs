using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary.CustomException
{
    public class DuplicateDoctorException : Exception
    {
        string msg;
        public DuplicateDoctorException()
        {
            msg = "Doctor name already exists";
        }
        public override string Message => msg;
    }
}
