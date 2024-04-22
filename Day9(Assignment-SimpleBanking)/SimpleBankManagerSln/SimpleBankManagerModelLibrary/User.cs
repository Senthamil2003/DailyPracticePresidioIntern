namespace SimpleBankManagerModelLibrary
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public double MobileNumber {  get; set; }
        public DateTime DateOfBirth { get; set; }
        

        public User() { 
            UserId = 0;
            MobileNumber = 0;
            DateOfBirth = DateTime.MinValue;
            Name = string.Empty;

        }
        public User(string Name, double MobileNumber, DateTime DateOfBirth)
        {
            this.Name = Name;
            this.MobileNumber = MobileNumber;
            this.DateOfBirth = DateOfBirth;
        }




       



    }
}
