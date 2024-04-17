namespace HospitalTrackerModelLibrary
{
    public class Doctor:Person
    {
        public int Experience { get; set; } = 0;



        public override bool Equals(object? obj)
        {
            return Name.Equals((obj as Doctor)?.Name);
        }

    }
}
