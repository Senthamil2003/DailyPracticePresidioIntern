using DoctorPatientAppointmentBLLLibrary.CustomException;
using DoctorPatientAppointmentDALLibrary;
using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int ,Appointment> _appointmentService;
        public AppointmentBL() { 
            _appointmentService=new AppointmentRepository();
        }
        public Appointment AddAppointment(Appointment Appointment)
        {
            var result =_appointmentService.Add(Appointment);
            
            if (result != null)
            {
                return Appointment;
            }
            throw new DuplicateDoctorException();
        }


        public Appointment ChangeAppointmentDate(int AppointmentId, DateTime NewDate)
        {
            var result=GetAppointmentById(AppointmentId);
            if(result != null)
            {
                result.DateTime = NewDate;
                return _appointmentService.Update(result);
            }
            throw new NullValueReturnedException();
        }

        public Appointment GetAppointmentById(int id)
        {
            List<Appointment> appointments = _appointmentService.GetAll();
            foreach (Appointment appointment in appointments)
            {
                if(appointment.AppointmentId == id)
                {
                    return appointment;
                }
                
            }
            throw new NullValueReturnedException();

        }

        public List<Appointment> GetAppointmentList()
        {
            List<Appointment> appointments=_appointmentService.GetAll();
         
           if(appointments != null)
            {
                return appointments;
            }
           throw new NullValueReturnedException();  
        }
    }
}
