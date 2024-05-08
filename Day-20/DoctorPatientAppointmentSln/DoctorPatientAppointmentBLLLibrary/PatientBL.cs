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
    public class PatientBL : IPatientService
    {
        readonly IRepository<int,Patient> _PatientRepository;
        public PatientBL()
        {
            _PatientRepository = new PatientRepository();
        }

        public int AddPatient(Patient Patient)
        {
            var result = _PatientRepository.Add(Patient);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicatePatientException();
        }

        public Patient ChangePatientName(string PatientOldName, string PatientNewName)
        {
            var result = GetPatientByName(PatientOldName);
            if (result != null)
            {
                result.Name = PatientNewName;
                _PatientRepository.Update(result);
                return result;
            }
            throw new NullValueReturnedException();


        }

        public Patient GetPatientById(int id)
        {
            var result = _PatientRepository.Get(id);
            if (result != null)
            {
                return _PatientRepository.Get(id);
            }
            throw new NullValueReturnedException();

        }

        public Patient GetPatientByName(string PatientName)
        {
            List<Patient> Patient = _PatientRepository.GetAll();

            foreach (Patient value in Patient)
            {
                if (value.Name == PatientName)
                {
                    return value;
                }

            }
            throw new NullValueReturnedException();

        }


        public List<Patient> GetPatientList()
        {
            var result = _PatientRepository.GetAll();
            if (result != null)
            {
                return result;
            }

            throw new NullValueReturnedException();
        }
    }
}
