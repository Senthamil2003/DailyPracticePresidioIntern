using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary.CustomException
{
    public class NothingToChangeException:Exception
    {
        string msg;
        public NothingToChangeException() {
            msg = "Already in update Nothing To change";

        }
        public override string Message => msg;


    }
}
