namespace DoctorPatientAppointmentModelLibrary
{
    public class Person
    {
        private int v;

        public int Id { get; set; }    
        public string Name { get; set; }
        public int AppointmentId { get; set; }

        public Person()
        {
            Id= 0;
            Name = "";
            AppointmentId = 0;
        }

        public Person(string name)
        {
          
            Name = name;
        
        }
    }
}
