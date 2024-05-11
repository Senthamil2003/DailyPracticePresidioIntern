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
        Task<int> AddDoctor(Doctor Doctor);
        Task<Doctor> GetDoctorById(int id);
       Task<Doctor> GetDoctorByName(string DoctorName);
       Task <Doctor> UpdateAppointment(Doctor Doctor,int Appointmentid);
        Task<List<Doctor>> GetDoctorList();

    }
}
