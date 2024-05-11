using DoctorPatientAppointmentBLLLibrary;
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
        public DoctorBL DoctorBL;
        public SampleTest() { 
            DoctorBL = new DoctorBL();
        } 
        public async Task GetAllDoctor()
        {
            List<Doctor> doctors=await DoctorBL.GetDoctorList();
            foreach (Doctor doctor in doctors)
            {
                Console.WriteLine(doctor.Name);
            }


        }
        static async Task Main(string[] args)
        {
            SampleTest sampleTest = new SampleTest();   
            await sampleTest.GetAllDoctor();
        

            //HospitalManagerContext context = new HospitalManagerContext();
            //var doctors = context.Doctors.ToList();
            //foreach (Doctor areasItem in doctors)
            //{
            //    Console.WriteLine(areasItem.Name+" "+areasItem.ContactNumber);
            //}
            ////Doctor doctor = new Doctor()
            ////{
            ////    Id = 3,
            ////    Name = "tonny",
            ////    ContactNumber = 12121212,
            ////    Experience = 12

            ////};
            ////context.Doctors.Add(doctor);
            ////doctor = new Doctor()
            ////{
            ////    Id = 4,
            ////    Name = "ponny",
            ////    ContactNumber = 12121212,
            ////    Experience = 1

            ////};
            ////context.Doctors.Add(doctor);
            ////context.SaveChanges();

            ////Console.WriteLine("Operation success");

            ////Doctor result= doctors.SingleOrDefault(a => a.Name == "tonny");
            //// if(result!=null) {
            ////     result.Name = "Tonny stark";
            ////     context.Doctors.Update(result);
            ////     context.SaveChanges();
            //// }
            //Doctor result = doctors.SingleOrDefault(a => a.Name == "Tonny stark");
            //if (result != null)
            //{
              
            //    context.Doctors.Remove(result);
            //    context.SaveChanges();
            //}





        }
    }
}
