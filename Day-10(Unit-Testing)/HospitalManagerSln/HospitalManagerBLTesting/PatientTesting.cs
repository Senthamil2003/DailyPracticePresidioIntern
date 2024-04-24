using HospitalManagerBLLibrary.Services;
using HospitalManagerBLLibrary;
using HospitalManagerDALLibrary;
using HospitalManagerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagerBLLibrary.CustomException;

namespace HospitalManagerBLTesting
{
    public class PatientTesting
    {
        IRepository<int, Patient> _Patientrepository;
        IPatientService _PatientService;
        [SetUp]
        public void Setup()
        {
            _Patientrepository = new PatientRepository();
            Patient patient = new Patient("Sentha", "Mbbs");
            _Patientrepository.Add(patient);
            patient = new Patient("Seena", "Mbbs");
            _Patientrepository.Add(patient);
            _PatientService = new PatientBL(_Patientrepository);

        }
        //Get All Patient

        [Test]
        public void GetAllPatient()
        {
            var result = _PatientService.GetPatientList();
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.Pass();
        }
        [Test]
        public void ExceptionInGetAllPatient()
        {
            IPatientService service = new PatientBL();
            var exception = Assert.Throws<NullValueException>(() => service.GetPatientList());
            Assert.That(exception.Message, Is.EqualTo("No value Present in the Patient Database"));
            Assert.Pass();
        }

        //Adding Patient
        [Test]
        public void AddPatient()
        {
            Patient Patient = new Patient("poornesh", "BDS");
            int result = _PatientService.AddPatient(Patient);
            Assert.That(result, Is.EqualTo(3));
            Assert.Pass();
        }
        [Test]
        public void FailAddPatient()
        {
            Patient Patient = new Patient("Sentha", "BDS");
            Assert.Throws<DuplicateValueException>(() => _PatientService.AddPatient(Patient));
            Assert.Pass();
        }
        [Test]

        public void ExceptionInAddPatient()
        {
            Patient Patient = new Patient("Sentha", "BDS");
            var exception = Assert.Throws<DuplicateValueException>(() => _PatientService.AddPatient(Patient));
            Assert.That(exception.Message, Is.EqualTo("Duplicate Patient Exist"));
            Assert.Pass();
        }
        [Test]
        public void RetrivePatientById()
        {
            var result = _PatientService.GetPatientById(1);
            Assert.That(result.Name, Is.EqualTo("Sentha"));
            Assert.Pass();
        }
        [Test]
        public void ExceptionInRetrivePatientById()
        {


            var exception = Assert.Throws<NullValueException>(() => _PatientService.GetPatientById(300));
            Assert.That(exception.Message, Is.EqualTo("No value Present in the Patient Database"));
            Assert.Pass();


        }
        [Test]
        public void FailRetrivePatientById()
        {
            Assert.Throws<NullValueException>(() => _PatientService.GetPatientById(100));
            Assert.Pass();
        }
        [Test]
        public void ChangeName()
        {
            var result = _PatientService.ChangePatientName("Sentha", "SuperStar");
            Assert.That(result.Name, Is.EqualTo("SuperStar"));
            Assert.Pass();
        }


        [Test]  
        public void FailChangePatientName()
        {
        
            Assert.Throws<NullValueException>(() => _PatientService.ChangePatientName("parker","ko"));
            Assert.Pass();
        }

        [Test]
        public void ExceptionInChangePatientName()
        {
            Patient patient =new Patient(); 
            var exception = Assert.Throws<NullValueException>(() => _PatientService.ChangePatientName("dodo","kkoko"));
            Assert.That(exception.Message, Is.EqualTo("No value Present in the Patient Database"));
            Assert.Pass();

        }
    }
}
