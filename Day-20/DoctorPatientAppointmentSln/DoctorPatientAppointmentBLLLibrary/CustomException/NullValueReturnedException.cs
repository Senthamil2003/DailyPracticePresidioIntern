using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary.CustomException
{
    public class NullValueReturnedException:Exception
    {
        string msg;
        public NullValueReturnedException()
        {
            msg = "There is no data avalaiable in the database";

        }
        public override string Message => msg;

    }
}
