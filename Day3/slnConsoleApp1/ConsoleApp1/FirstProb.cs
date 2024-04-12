using System.Linq.Expressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Subract(int x, int y)
        {
            return y - x;
        }
        static float Divide(int x, int y)
        {
            return x / y;
        }
        static int product(int x, int y)
        {
            return x * y;
        }
        static int Modulo(int x, int y)
        {

            return x % y;
        }
        static int GetNum()
        {
            int num;
            Console.WriteLine("enter the number");
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Enter the valid input");
            return num;
        }

        static void Calculate(int option)
        {
            int x = GetNum();
            int y = GetNum();
            switch (option)
            {
                case 1:
                    Printfunction(Add(x, y), "Sum");
                    break;
                case 2:
                    Printfunction(Subract(x, y), "subraction");
                    break;
                case 3:
                    Printfunction((int)Divide(x, y), "Division");
                    break;
                case 4:
                    Printfunction(product(x, y), "Multiply");
                    break;
                case 5:
                    Printfunction(Modulo(x, y), "Modulo");
                    break;
                default:
                    Console.WriteLine("enter the correct option");
                    break;
            }



        }
        static void Printfunction(int result, string value)
        {
            Console.WriteLine($"The {value} of two values is {result}");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter option");
            int option;
            option = int.Parse(Console.ReadLine());
            Calculate(option);

        }
    }
}
