using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentBLLLibrary
{
    public interface IDoctorService
    {
        int AddDoctor(Doctor Doctor);
        Doctor GetDoctorById(int id);
        Doctor GetDoctorByName(string DoctorName);
        Doctor UpdateAppointment(Doctor Doctor,int Appointmentid);
        List<Doctor> GetDoctorList();

    }
}
