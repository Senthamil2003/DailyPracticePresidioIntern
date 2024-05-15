namespace HospitalTrackerBLLibrary
{
   public class Animal
    {
        public  string name { get; set; } = "sentha";
    }
    public class Dog:Animal
    {
        public string DogName { get; set; } = "Pug";
    }
    public class Class1
    {
        static void Main(string[] args)
        {
          Animal dog = new Dog();
          Console.WriteLine(dog.name);

        }
    }


    }
    

