using DoctorClinicManagerWebApi.Context;
using DoctorClinicManagerWebApi.CustomException;
using DoctorClinicManagerWebApi.Interface;
using DoctorClinicManagerWebApi.Models;

namespace DoctorClinicManagerWebApi.Repository
{
    public class DoctorRepository : IReposiroty<int, Doctor>
    {
        private readonly DoctorManagerContext _context;
        public DoctorRepository(DoctorManagerContext context) {
            _context=context;   
        }   
        public async Task<Doctor> Add(Doctor item)
        {
            try
            {
                 _context.Add(item);
                 await _context.SaveChangesAsync();
                return item;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Doctor> Delete(int key)
        {
            try
            {
                Doctor doctor=await Get(key);
                if(doctor!=null)
                {
                    _context.Remove(doctor);
                    return doctor;
                }
                throw new NullValueException();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Doctor> Get(int key)
        {

            try
            {
               Doctor doctor= _context.Doctors.ToList().FirstOrDefault(d => d.DoctorId == key);
                if(doctor!=null)
                {
                    return doctor;
                }
                throw new NoDoctorFoundException();


            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Doctor>> Get()
        {

            try
            {
                return _context.Doctors;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Doctor> Update(Doctor item)
        {

            try
            {
                if (item != null)
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return item;
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
