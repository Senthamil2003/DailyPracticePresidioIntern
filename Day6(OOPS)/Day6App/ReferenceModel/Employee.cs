namespace ReferenceModel
{
    public class Employee:InternalCompanyWork
    {
        int Age;
        DateTime DateOfBirth;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; }=string.Empty;
        public int age
        {
            get => Age;
            set => Age = value;
        }
        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
        }
        public Employee(int id, string name, DateTime dateOfBirth)
        {
            Console.WriteLine("Employee class prameterized constructor");
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }
        public DateTime dateOfBirth
        {
            get => DateOfBirth;
            set
            {
                DateOfBirth = value;
            }
        }
        public double Salary { get; set; }
        public virtual void GetEmployeeDetails()
        {
            Console.WriteLine("Enter your Name");
            Name = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Date Of Birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Age");
            Age = Convert.ToInt32(Console.ReadLine());
           
        }
        public virtual void printEmployee()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Employee Id {Id}");
            Console.WriteLine($"Employee name {Name} ");
            Console.WriteLine($"Employee DateofBirth {DateOfBirth}");
            Console.WriteLine($"Employee Age {Age}");
           
            Console.WriteLine("-------------------------------------------------");

        }
        public void GetOrder()
        {
            Console.WriteLine("Order by"+Name);

        }
        public virtual void GetPayment() {
            Console.WriteLine("Payment by"+Name);
        }

    }
}
