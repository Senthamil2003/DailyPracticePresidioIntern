
using HospitalTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointment;
        public AppointmentRepository()
        {
            _appointment = new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {
            if (_appointment.Count == 0)
                return 1;
            int id = _appointment.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (_appointment.ContainsValue(item))
            {
                return null;
            }
            _appointment.Add(GenerateId(), item);
            return item;

        }


        public Appointment Delete(int key)
        {
            if (_appointment.ContainsKey(key))
            {
                var department = _appointment[key];
                _appointment.Remove(key);
                return department;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            return _appointment.ContainsKey(key) ? _appointment[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointment.Count == 0)
                return null;
            return _appointment.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_appointment.ContainsKey(item.AppointmentId))
            {
                _appointment[item.AppointmentId] = item;
                return item;
            }
            return null;
        }
    }
}
