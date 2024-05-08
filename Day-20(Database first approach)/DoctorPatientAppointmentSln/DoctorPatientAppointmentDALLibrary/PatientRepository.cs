using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _Patients;
        public PatientRepository()
        {
            _Patients = new Dictionary<int, Patient>();
        }
        public int GenerateId()
        {

            if (_Patients.Count == 0)
                return 1;
            int id = _Patients.Keys.Max();
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (_Patients.ContainsValue(item))
            {
                return null;
            }
            int id = GenerateId();
            item.Id = id;
            _Patients.Add(id, item);
            return item;
        }

        public Patient Delete(int key)
        {
            if (_Patients.ContainsKey(key))
            {
                var Patient = _Patients[key];
                _Patients.Remove(key);
                return Patient;
            }
            return null;
        }

        public Patient? Get(int key)
        {
            return _Patients.ContainsKey(key) ? _Patients[key] : null;
        }

        public List<Patient> GetAll()
        {
            if (_Patients.Count == 0)
                return null;
            return _Patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_Patients.ContainsKey(item.Id))
            {
                _Patients[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}

