using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        public readonly HospitalManagerContext _context;
        public AppointmentRepository(HospitalManagerContext context)
        {
            _context = context;
        }
        public async Task<Appointment> Add(Appointment entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Appointment> Delete(int key)
        {
            try
            {
                Appointment Appointment = await Get(key);
               
                 _context.Remove(Appointment);
                  await _context.SaveChangesAsync();
                  return Appointment;
              
             
            }
            catch
            {
                throw;
            }


        }

        public virtual async Task<Appointment> Get(int key)
        {
            Appointment Appointment = _context.Appointments.FirstOrDefault(e => e.AppointmentId == key);
           
            return Appointment;
            
           

        }

        public virtual async Task<List<Appointment>> GetAll()
        {

            return _context.Appointments.ToList();
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}

