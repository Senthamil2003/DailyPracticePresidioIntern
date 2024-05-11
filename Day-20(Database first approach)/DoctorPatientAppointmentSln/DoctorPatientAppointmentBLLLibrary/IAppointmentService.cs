using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary
{
    public interface IAppointmentService
    {
        Task<Appointment> AddAppointment(Appointment Appointment);
        Task<Appointment> ChangeAppointmentDate(int AppointmentId, DateTime NewDate);
        Task<Appointment> GetAppointmentById(int id);
       Task< List<Appointment>> GetAppointmentList();

    }

}
