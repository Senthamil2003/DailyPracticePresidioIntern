using DoctorPatientAppointmentBLLLibrary.CustomException;
using DoctorPatientAppointmentDALLibrary;
using DoctorPatientAppointmentDALLibrary.Model;
using DoctorPatientPatientDALLibrary;
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
            _PatientRepository = new PatientRepository(new HospitalManagerContext());
        }

        public async Task<int> AddPatient(Patient Patient)
        {
            var result =await _PatientRepository.Add(Patient);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicatePatientException();
        }

        public async Task<Patient> ChangePatientName(string PatientOldName, string PatientNewName)
        {
            var result =await GetPatientByName(PatientOldName);
            if (result != null)
            {
                result.Name = PatientNewName;
               await _PatientRepository.Update(result);
                return result;
            }
            throw new NullValueReturnedException();


        }

        public async Task<Patient> GetPatientById(int id)
        {
            var result = await _PatientRepository.Get(id);
            if (result != null)
            {
                return await _PatientRepository.Get(id);
            }
            throw new NullValueReturnedException();

        }

        public async Task<Patient> GetPatientByName(string PatientName)
        {
            List<Patient> Patient = await _PatientRepository.GetAll();

            foreach (Patient value in Patient)
            {
                if (value.Name == PatientName)
                {
                    return value;
                }

            }
            throw new NullValueReturnedException();

        }


        public async Task<List<Patient>> GetPatientList()
        {
            var result = await _PatientRepository.GetAll();
            if (result != null)
            {
                return result;
            }

            throw new NullValueReturnedException();
        }
    }
}
