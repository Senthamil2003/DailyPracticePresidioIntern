using HospitalManagerModelLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerBLLibrary.Services
{
    public interface IAppointmentService
    {
        Appointment AddAppointment(Appointment Appointment);
        Appointment ChangeAppointmentDate(int AppointmentId, DateTime NewDate);
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAppointmentList();

    }
}
