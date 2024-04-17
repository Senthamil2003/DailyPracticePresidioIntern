using HospitalTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTrackerBLLibrary
{
    public interface IPatientService
    {
        Doctor CreateDoctor(Doctor item);

        List<Doctor> GetAllDoctors();   

        Doctor GetDoctor(int DoctorId);

        Doctor UpdateDoctorDetails(Doctor item);    

        Doctor FireDoctor(int DoctorId); 
    }
}
