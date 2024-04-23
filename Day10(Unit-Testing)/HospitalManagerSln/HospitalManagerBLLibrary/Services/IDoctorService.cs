using HospitalManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerBLLibrary.Services
{
    public interface IDoctorService
    {
        int AddDoctor(Doctor Doctor);
        Doctor GetDoctorById(int id);
        Doctor UpdateAppointment(Doctor Doctor, int Appointmentid);
        List<Doctor> GetDoctorList();

    }
}
