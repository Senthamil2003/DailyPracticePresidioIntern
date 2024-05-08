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
        int AddPatient(Patient Patient);
        Patient ChangePatientName(string PatientOldName, string PatientNewName);
        Patient GetPatientById(int id);
        Patient GetPatientByName(string PatientName);

        List<Patient> GetPatientList();

    }

}
