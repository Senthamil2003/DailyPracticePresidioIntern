using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _Appointments;
        public AppointmentRepository()
        {
            _Appointments = new Dictionary<int, Appointment>();
        }
         int GenerateId()
        {

            if (_Appointments.Count == 0)
                return 1;
            int id = _Appointments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
           
            if (_Appointments.ContainsValue(item))
            {
                return null;
            }
            int id = GenerateId();
            item.AppointmentId= id;
            _Appointments.Add(id, item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_Appointments.ContainsKey(key))
            {
                var Appointment = _Appointments[key];
                _Appointments.Remove(key);
                return Appointment;
            }
            return null;
        }

        public Appointment? Get(int key)
        {
            return _Appointments.ContainsKey(key) ? _Appointments[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_Appointments.Count == 0)
                return null;
            return _Appointments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_Appointments.ContainsKey(item.AppointmentId))
            {
                _Appointments[item.AppointmentId] = item;
                return item;
            }
            return null;
        }
    }
}

