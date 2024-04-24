namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        int Age;
        DateTime DateOfBirth;
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public int age
        {
            get => Age;
            set => Age = value; 
        }
        public DateTime dateOfBirth {
            get => DateOfBirth;
            set
            {
                DateOfBirth = value; 
            }
        }
      



        public double Salary { get; set; }
        public void GetEmployeeDetails()
        {
            Console.WriteLine("Enter your Name");
            Name = Console.ReadLine()??"";
            Console.WriteLine("Enter Date Of Birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Age");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Salary");
            Salary= Convert.ToDouble(Console.ReadLine());
        }
        public void printEmployee()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Employee Id {Id}");
            Console.WriteLine($"Employee name {Name} ");
            Console.WriteLine($"Employee DateofBirth {DateOfBirth}");
            Console.WriteLine($"Employee Age {Age}");
            Console.WriteLine($"Employee Salary {Salary}");
            Console.WriteLine("-------------------------------------------------");

        }


    }
}
