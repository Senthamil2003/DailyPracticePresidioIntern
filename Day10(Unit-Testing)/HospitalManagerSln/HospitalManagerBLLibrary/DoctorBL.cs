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
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _Doctor;
        public DoctorBL()
        {
            _Doctor = new DoctorRepository();
        }
        [ExcludeFromCodeCoverage]
        public DoctorBL(IRepository<int,Doctor> doctor)
        {
            _Doctor = doctor;
        }
        public int AddDoctor(Doctor doctor)
        {
            var result = _Doctor.Add(doctor);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateValueException("Duplicate Doctor value found");
        }

        public Doctor GetDoctorById(int id)
        {
            var result = _Doctor.Get(id);
            if (result != null)
            {
                return result;
            }
            throw new NullValueException("No values find in the Doctor Database");
        }

      

        public List<Doctor> GetDoctorList()
        {

            List<Doctor> doctor = _Doctor.GetAll();
            if (doctor != null)
                return doctor;
            throw new NullValueException("No values find in the Doctor Database");

        }

        public Doctor UpdateAppointment(Doctor doctor, int Appointmentid)
        {
            doctor.AppointmentId.Add(Appointmentid);
            var result = _Doctor.Update(doctor);
            if (result != null)
            {
                return result;
            }
            throw new NullValueException("No values find in the Doctor Database");

        }
    }
}
