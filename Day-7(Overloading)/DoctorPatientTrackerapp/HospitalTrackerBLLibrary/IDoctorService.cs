using HospitalTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerBLLibrary
{
    public  interface IDoctorService
    {
        Patient CreatePatient(Patient patient);
        List<Patient> GetAllPatients();

        Patient GetPatient(int id);

        Patient UpdatePatient(Patient patient);

        Patient RemovePatient(int PatientId);

    }
}
