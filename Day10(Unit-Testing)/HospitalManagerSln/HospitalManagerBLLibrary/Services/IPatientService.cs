using HospitalManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerBLLibrary.Services
{
    public interface IPatientService
    {
        int AddPatient(Patient Patient);
        Patient ChangePatientName(string PatientOldName, string PatientNewName);
        Patient GetPatientById(int id);
       
        List<Patient> GetPatientList();

    }
}
