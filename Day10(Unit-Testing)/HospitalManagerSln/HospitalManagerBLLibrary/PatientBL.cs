using HospitalManagerBLLibrary.CustomException;
using HospitalManagerBLLibrary.Services;
using HospitalManagerDALLibrary;
using HospitalManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerBLLibrary
{
    public class PatientBL : IPatientService
    {
        readonly IRepository<int, Patient> _PatientRepository;
        public PatientBL()
        {
            _PatientRepository = new PatientRepository();
        }
        [ExcludeFromCodeCoverage]
        public PatientBL(IRepository<int, Patient> _patient)
        {
            _PatientRepository = _patient;
        }

        public int AddPatient(Patient Patient)
        {
            var result = _PatientRepository.Add(Patient);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateValueException("Duplicate Patient Exist");
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
            throw new NullValueException("No value Present in the Patient Database");


        }

        public Patient GetPatientById(int id)
        {
            var result = _PatientRepository.Get(id);
            if (result != null)
            {
                return _PatientRepository.Get(id);
            }
            throw new NullValueException("No value Present in the Patient Database");

        }
        [ExcludeFromCodeCoverage]
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
            throw new NullValueException("No value Present in the Patient Database");

        }


        public List<Patient> GetPatientList()
        {
            var result = _PatientRepository.GetAll();
            if (result != null)
            {
                return result;
            }

            throw new NullValueException("No value Present in the Patient Database");
        }
    }
}
