using HospitalManagerBLLibrary;
using HospitalManagerBLLibrary.CustomException;
using HospitalManagerBLLibrary.Services;
using HospitalManagerDALLibrary;
using HospitalManagerModelLibrary;
using System.Numerics;

namespace HospitalManagerBLTesting
{
    public class Tests
    {
        IRepository<int,Doctor> _Doctorrepository;
        IDoctorService _DoctorService;
        [SetUp]
        public void Setup()
        {
            _Doctorrepository = new DoctorRepository();
            Doctor doctor = new Doctor("Sentha","Mbbs");
            _Doctorrepository.Add(doctor);
            doctor = new Doctor("Seena", "Mbbs");
            _Doctorrepository.Add(doctor);
            _DoctorService = new DoctorBL(_Doctorrepository);

        }
        //Get All Doctor

        [Test]
        public void GetAllDoctor()
        {
            var result=_DoctorService.GetDoctorList();
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.Pass();
        }
    
        [Test]
        public void ExceptionInGetAllDoctor()
        {
            IDoctorService service = new DoctorBL();
            var exception = Assert.Throws<NullValueException>(() => service.GetDoctorList());
            Assert.That(exception.Message, Is.EqualTo("No values find in the Doctor Database"));
            Assert.Pass();
        }
        //Adding Doctor
        [Test]
        public void AddDoctor()
        {
            Doctor doctor = new Doctor("poornesh", "BDS");
            int result=_DoctorService.AddDoctor(doctor);
            Assert.That(result,Is.EqualTo(3));
            Assert.Pass();
        }
        [Test]
        public void FailAddDoctor()
        {
            Doctor doctor = new Doctor("Sentha", "BDS");
            Assert.Throws<DuplicateValueException>(() => _DoctorService.AddDoctor(doctor));
            Assert.Pass();
        }
        [Test]

        public void ExceptionInAddDoctor()
        {
            Doctor doctor = new Doctor("Sentha", "BDS");
            var exception = Assert.Throws<DuplicateValueException>(() => _DoctorService.AddDoctor(doctor));
            Assert.That(exception.Message, Is.EqualTo("Duplicate Doctor value found"));
            Assert.Pass();
        }
        [Test]
        public void RetriveDoctorById()
        {
            var result=_DoctorService.GetDoctorById(1);
            Assert.That(result.Name, Is.EqualTo("Sentha"));
            Assert.Pass();
        }
        [Test]
        public void ExceptionInRetriveDoctorById()
        {

           
            var exception = Assert.Throws<NullValueException>(() => _DoctorService.GetDoctorById(300));
            Assert.That(exception.Message, Is.EqualTo("No values find in the Doctor Database"));
            Assert.Pass();


        }
        [Test]
        public void FailRetriveDoctorById()
        {
            Assert.Throws<NullValueException>(() => _DoctorService.GetDoctorById(100));
            Assert.Pass();
        }

        //Update Doctor

        [Test]
        public void UpdateDoctor()
        {
         
             var doctor=  _DoctorService.GetDoctorById(1);
            var result =_DoctorService.UpdateAppointment(doctor, 10);
            Assert.That(result.AppointmentId[0], Is.EqualTo(10));
            Assert.Pass();
        }

        [Test]
        public void FailUpdateDoctor()
        {
            var doctor = _DoctorService.GetDoctorById(1);
            doctor.Id = 10;
            Assert.Throws<NullValueException>(() => _DoctorService.UpdateAppointment(doctor,10));
            Assert.Pass();

        }
        [Test]
        public void ExceptionInUpdateDoctor()
        {
            var doctor = _DoctorService.GetDoctorById(1);
            doctor.Id = 10;
            var exception = Assert.Throws<NullValueException>(() => _DoctorService.UpdateAppointment(doctor,10));
            Assert.That(exception.Message, Is.EqualTo("No values find in the Doctor Database"));
            Assert.Pass();

        }
    }
}