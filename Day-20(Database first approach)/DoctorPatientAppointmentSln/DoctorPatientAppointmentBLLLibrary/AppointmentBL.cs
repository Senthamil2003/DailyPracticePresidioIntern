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
            _appointmentService=new AppointmentRepository(new HospitalManagerContext());
        }
        public async Task<Appointment> AddAppointment(Appointment Appointment)
        {
            var result = await _appointmentService.Add(Appointment);
            
            if (result != null)
            {
                return  Appointment;
            }
            throw new DuplicateDoctorException();
        }


        public async Task<Appointment> ChangeAppointmentDate(int AppointmentId, DateTime NewDate)
        {
            var result=await GetAppointmentById(AppointmentId);
            if(result != null)
            {
                result.DateTime = NewDate;
                return await _appointmentService.Update(result);
            }
            throw new NullValueReturnedException();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            List<Appointment> appointments = await _appointmentService.GetAll();
            foreach (Appointment appointment in appointments)
            {
                if(appointment.AppointmentId == id)
                {
                    return appointment;
                }
                
            }
            throw new NullValueReturnedException();

        }

        public async Task< List<Appointment>> GetAppointmentList()
        {
            List<Appointment> appointments=await _appointmentService.GetAll();
         
           if(appointments != null)
            {
                return appointments;
            }
           throw new NullValueReturnedException();  
        }
    }
}
