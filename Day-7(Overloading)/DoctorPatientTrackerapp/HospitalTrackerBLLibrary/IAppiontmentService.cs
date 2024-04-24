using HospitalTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerBLLibrary
{
    public interface IAppiontmentService
    {
        Appointment CreateAppointment(Appointment item);
        List<Appointment> GetAppointmentList();
        Appointment GetAppointmentById(int AppointmantId);

        List<Appointment> GetAllDoctorsAppointments(int DoctorId);

        List<Appointment> GetAllPatientAppointment(int PatientId);

       
        Appointment RescheduleAppointment(Appointment item);


    }
}
