using DoctorPatientAppointmentDALLibrary;
using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientDoctorDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        public readonly HospitalManagerContext _context;
        public DoctorRepository(HospitalManagerContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Doctor> Delete(int key)
        {
            try
            {
                Doctor Doctor = await Get(key);

                _context.Remove(Doctor);
                await _context.SaveChangesAsync();
                return Doctor;


            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Doctor> Get(int key)
        {
            Doctor Doctor = _context.Doctors.FirstOrDefault(e => e.Id == key);

            return Doctor;



        }

        public virtual async Task<List<Doctor>> GetAll()
        {

            return _context.Doctors.ToList();
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}

