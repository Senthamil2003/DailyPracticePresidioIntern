using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary
{
    public interface IPatientService
    {
        Task<int> AddPatient(Patient Patient);
        Task<Patient> ChangePatientName(string PatientOldName, string PatientNewName);
        Task<Patient> GetPatientById(int id);
        Task<Patient> GetPatientByName(string PatientName);

        Task<List<Patient>> GetPatientList();

    }

}
