using HospitalTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerDALLibrary
{
    internal class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patient;
        public PatientRepository()
        {
            _patient = new Dictionary<int, Patient>();   
        }
        int GenerateId()
        {
            if (_patient.Count == 0)
                return 1;
            int id = _patient.Keys.Max();
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (_patient.ContainsValue(item))
            {
                return null;
            }
            _patient.Add(GenerateId(), item);
            return item;

        }

        public Patient Delete(int key)
        {
            if (_patient.ContainsKey(key))
            {
                var department = _patient[key];
                _patient.Remove(key);
                return department;
            }
            return null;
        }

        public Patient Get(int key)
        {
            return _patient.ContainsKey(key) ? _patient[key] : null;
        }

        public List<Patient> GetAll()
        {
            if (_patient.Count == 0)
                return null;
            return _patient.Values.ToList();

        }

        public Patient Update(Patient item)
        {
            if (_patient.ContainsKey(item.Id))
            {
                _patient[item.Id] = item;
                return item;
            }
            return null;

        }
    }
}
