namespace HospitalManagerModelLibrary
{
    public class Patient : Person
    {
        string Disease { get; set; }
        public Patient()
        {
            Disease = string.Empty;
        }
        public Patient(string name, string disease) : base(name)
        {
            Disease = disease;

        }
        public override bool Equals(object? obj)
        {

            return this.Name.Equals((obj as Patient).Name);
        }
        public override string ToString()
        {

            return "Person Id: " + Id + "person name: " + Name + "\n" + "Disease Name: " + Disease;

        }


    }
}
