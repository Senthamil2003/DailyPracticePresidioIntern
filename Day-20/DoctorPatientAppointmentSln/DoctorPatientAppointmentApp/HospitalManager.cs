//using DoctorPatientAppointmentBLLLibrary;
//using DoctorPatientAppointmentModelLibrary;

//namespace DoctorPatientAppointmentApp
//{
//    internal class HospitalManager
//    {
//        IDoctorService _doctor;
//        IPatientService _patient;
//        IAppointmentService _appointment;
//        public HospitalManager()
//        {
//            _doctor = new DoctorBL();
//            _patient= new PatientBL();
//            _appointment= new AppointmentBL();

//        }
//        void AddData()
//        {
//            try {
//                Doctor doctor1 = new Doctor("sentha", "MBBS");
//                _doctor.AddDoctor(doctor1);
//                Doctor doctor2 = new Doctor("sena", "BDS");
//                _doctor.AddDoctor(doctor2);
//                Doctor doctor3 = new Doctor("Poornesh", "MBBS");
//                _doctor.AddDoctor(doctor3);
//                Patient patient1 = new Patient("Joe", "Mental");
//                Patient patient2 = new Patient("bob", "Aids");
//                Patient patient3 = new Patient("sally", "Brain Tumor");
//                _patient.AddPatient(patient1);
//                _patient.AddPatient(patient2);
//                _patient.AddPatient(patient3);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
            

//        }
//        void GetAll()
//        {
//            try
//            {
//                List<Patient> patients = _patient.GetPatientList();
//                List<Doctor> doctors = _doctor.GetDoctorList();
//                foreach (Patient patient in patients)
//                {
//                    Console.WriteLine(patient.ToString());

//                }
//                foreach (Doctor doctor in doctors)
//                {
//                    Console.WriteLine(doctor.ToString());
//                }

//            }
//            catch(Exception e) {
//                Console.WriteLine(e.Message);
//            }

           
//        }
//        void AddAppointment()
//        {
//            try
//            {
//                Console.WriteLine("Enter patient Id");
//                int patientId = Convert.ToInt32(Console.ReadLine());
//                Console.WriteLine("Enter Doctor Id");
//                int doctorId = Convert.ToInt32(Console.ReadLine());
//                Doctor doctor=_doctor.GetDoctorById(doctorId);
//                Patient patient=_patient.GetPatientById(patientId);
//                Appointment appointment = new Appointment("sample",DateTime.Now,doctor,patient);
//                _appointment.AddAppointment(appointment);
//                _doctor.UpdateAppointment(doctor, appointment.AppointmentId);

//                //***************************************************************//

//                Console.WriteLine("Enter patient Id");
//                patientId = Convert.ToInt32(Console.ReadLine());
//                Console.WriteLine("Enter Doctor Id");
//                doctorId = Convert.ToInt32(Console.ReadLine());
//                 doctor = _doctor.GetDoctorById(doctorId);
//                patient = _patient.GetPatientById(patientId);
//                Appointment appointment2 = new Appointment("Bample", DateTime.Now, doctor, patient);
//                _appointment.AddAppointment(appointment2);
//                _doctor.UpdateAppointment(doctor, appointment2.AppointmentId);

//                Console.WriteLine("ji"+appointment2.AppointmentId);
//                List<Appointment> appointments = _appointment.GetAppointmentList();
//                foreach (Appointment appointment1 in appointments)
//                {
//                    Console.WriteLine(appointment1.AppointmentId);
//                    Console.WriteLine(appointment1.Patient.Name);
//                    Console.WriteLine(appointment1.Doctor.Name);
//                    Console.WriteLine(appointment1.DateTime);
//                    Console.WriteLine(appointment1.Title);
//                }
                



//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
           


//        }
        
//        static void Main(string[] args)
//        {
//            HospitalManager hospitalManager = new HospitalManager();
//            hospitalManager.AddData();
//            hospitalManager.GetAll();
//            hospitalManager.AddAppointment();
//        }
//    }
//}
