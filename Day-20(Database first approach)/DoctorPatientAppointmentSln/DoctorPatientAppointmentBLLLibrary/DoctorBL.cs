
using DoctorPatientAppointmentBLLLibrary.CustomException;
using DoctorPatientAppointmentDALLibrary;
using DoctorPatientAppointmentDALLibrary.Model;
using DoctorPatientDoctorDALLibrary;


namespace DoctorPatientAppointmentBLLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _Doctor;
        public DoctorBL()
        {
           _Doctor=new DoctorRepository(new HospitalManagerContext());
        }
        public async Task<int> AddDoctor(Doctor doctor)
        {
            var result=await _Doctor.Add(doctor);
            if(result != null) {
                return result.Id;
            }
            throw new DuplicateDoctorException();   
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var result =await _Doctor.Get(id);
            if (result != null)
            {
                return result;
            }
            throw new NullValueReturnedException();
        }

        public async Task<Doctor> GetDoctorByName(string DoctorName)
        {
            List<Doctor> doctor =await _Doctor.GetAll();

            foreach (Doctor value in doctor)
            {
                if (value.Name == DoctorName)
                {
                    return value;
                }

            }
            throw new NullValueReturnedException();
        }

        public async Task<List<Doctor>> GetDoctorList()
        {
            List<Doctor> doctor = await _Doctor.GetAll();
            if(doctor != null)
            return doctor;
            throw new NullValueReturnedException();

        }

        public async Task<Doctor> UpdateAppointment(Doctor Doctor, int Appointmentid)
        {
            throw new NotImplementedException();
        }
    }
}
