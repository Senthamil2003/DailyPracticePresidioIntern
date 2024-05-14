using DoctorClinicManagerWebApi.CustomException;
using DoctorClinicManagerWebApi.Interface;
using DoctorClinicManagerWebApi.Models;

namespace DoctorClinicManagerWebApi.DoctorBusinessLogic
{
    public class DoctorBL : IDoctorService
    {
        private readonly IReposiroty<int, Doctor> _doctorrepo;
        public DoctorBL(IReposiroty<int ,Doctor> doctorrepo)
        {
            _doctorrepo=doctorrepo;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {

            try
            {
                return await _doctorrepo.Get(); 
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByspeciality(string speciality)
        {
            try
            {
                IEnumerable<Doctor> doctors = (await _doctorrepo.Get()).Where(d=>d.Speciality==speciality);
                return doctors;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Doctor> UpdateDocotrExperience(int id, int experience)
        {

            try
            {
                Doctor doctor=await _doctorrepo.Get(id);
                if (doctor != null)
                {
                  doctor.Experience = experience;
                  await  _doctorrepo.Update(doctor);
                  return doctor;
                }
                throw new NullValueException();
            }
            catch
            {
                throw;
            }
        }
    }
}
