using DoctorPatientAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAppointmentApp
{
    public class SampleTest
    {
        static void Main(string[] args)
        {
            HospitalManagerContext context = new HospitalManagerContext();
            var doctors = context.Doctors.ToList();
            foreach (Doctor areasItem in doctors)
            {
                Console.WriteLine(areasItem.Name+" "+areasItem.ContactNumber);
            }
            //Doctor doctor = new Doctor()
            //{
            //    Id = 3,
            //    Name = "tonny",
            //    ContactNumber = 12121212,
            //    Experience = 12

            //};
            //context.Doctors.Add(doctor);
            //doctor = new Doctor()
            //{
            //    Id = 4,
            //    Name = "ponny",
            //    ContactNumber = 12121212,
            //    Experience = 1

            //};
            //context.Doctors.Add(doctor);
            //context.SaveChanges();

            //Console.WriteLine("Operation success");

            //Doctor result= doctors.SingleOrDefault(a => a.Name == "tonny");
            // if(result!=null) {
            //     result.Name = "Tonny stark";
            //     context.Doctors.Update(result);
            //     context.SaveChanges();
            // }
            Doctor result = doctors.SingleOrDefault(a => a.Name == "Tonny stark");
            if (result != null)
            {
              
                context.Doctors.Remove(result);
                context.SaveChanges();
            }





        }
    }
}
