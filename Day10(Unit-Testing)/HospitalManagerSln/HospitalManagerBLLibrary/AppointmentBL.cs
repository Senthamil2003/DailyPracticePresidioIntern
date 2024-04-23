using HospitalManagerDALLibrary;
using HospitalManagerModelLibrary;
using HospitalManagerBLLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagerBLLibrary.Services;

namespace HospitalManagerBLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentService;
        public AppointmentBL()
        {
            _appointmentService = new AppointmentRepository();
        }
        public AppointmentBL(IRepository<int, Appointment> _appointment)
        {
            _appointmentService = _appointment;
        }
        public Appointment AddAppointment(Appointment Appointment)
        {
            var result = _appointmentService.Add(Appointment);

            if (result != null)
            {
                return Appointment;
            }
            throw new DuplicateValueException("Duplicate Appointment Exception");
        }


        public Appointment ChangeAppointmentDate(int AppointmentId, DateTime NewDate)
        {
            var result = GetAppointmentById(AppointmentId);
            if (result != null)
            {
                result.DateTime = NewDate;
                return _appointmentService.Update(result);
            }
            throw new NullValueException("No Appointment Available in database");

        }

        public Appointment GetAppointmentById(int id)
        {
            List<Appointment> appointments = _appointmentService.GetAll();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.AppointmentId == id)
                {
                    return appointment;
                }

            }
            throw new NullValueException("No Appointment Available in database");

        }

        public List<Appointment> GetAppointmentList()
        {
            List<Appointment> appointments = _appointmentService.GetAll();
            foreach (Appointment appointment in appointments)
            {
                Console.WriteLine(appointment.Title);
            }
            if (appointments != null)
            {
                return appointments;
            }
            throw new NullValueException("No values find in the Doctor Database");
        }
    }
}
