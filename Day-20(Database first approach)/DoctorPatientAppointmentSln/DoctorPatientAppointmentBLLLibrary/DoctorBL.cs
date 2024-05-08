
using DoctorPatientAppointmentBLLLibrary.CustomException;
using DoctorPatientAppointmentDALLibrary;
using DoctorPatientAppointmentDALLibrary.Model;


namespace DoctorPatientAppointmentBLLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _Doctor;
        public DoctorBL()
        {
           _Doctor=new DoctorRepository();
        }
        public int AddDoctor(Doctor doctor)
        {
            var result= _Doctor.Add(doctor);
            if(result != null) {
                return result.Id;
            }
            throw new DuplicateDoctorException();   
        }

        public Doctor GetDoctorById(int id)
        {
            var result =_Doctor.Get(id);
            if (result != null)
            {
                return result;
            }
            throw new NullValueReturnedException();
        }

        public Doctor GetDoctorByName(string DoctorName)
        {
            List<Doctor> doctor = _Doctor.GetAll();

            foreach (Doctor value in doctor)
            {
                if (value.Name == DoctorName)
                {
                    return value;
                }

            }
            throw new NullValueReturnedException();
        }

        public List<Doctor> GetDoctorList()
        {
            List<Doctor> doctor = _Doctor.GetAll();
            if(doctor != null)
            return doctor;
            throw new NullValueReturnedException();

        }

        public Doctor UpdateAppointment(Doctor Doctor, int Appointmentid)
        {
            throw new NotImplementedException();
        }
    }
}
