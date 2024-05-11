using DoctorPatientAppointmentDALLibrary;
using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientPatientDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        public readonly HospitalManagerContext _context;
        public PatientRepository(HospitalManagerContext context)
        {
            _context = context;
        }
        public async Task<Patient> Add(Patient entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Patient> Delete(int key)
        {
            try
            {
                Patient Patient = await Get(key);

                _context.Remove(Patient);
                await _context.SaveChangesAsync();
                return Patient;


            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Patient> Get(int key)
        {
            Patient Patient = _context.Patients.FirstOrDefault(e => e.Id == key);

            return Patient;



        }

        public virtual async Task<List<Patient>> GetAll()
        {

            return _context.Patients.ToList();
        }

        public async Task<Patient> Update(Patient entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}

