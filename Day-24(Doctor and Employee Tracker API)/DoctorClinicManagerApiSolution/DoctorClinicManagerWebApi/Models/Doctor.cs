namespace DoctorClinicManagerWebApi.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }   
        public string Speciality { get; set; }
        public int Experience { get; set; }

    }
}
