using DoctorClinicManagerWebApi.Models;

namespace DoctorClinicManagerWebApi.Interface
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorsByspeciality(string speciality);
        public Task<Doctor> UpdateDocotrExperience(int id,int experience);

     
    }
}
