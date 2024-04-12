using System.Linq.Expressions;

namespace ConsoleApp1
{
    internal class SecondProb
    {
        static bool ReadNumber(out int num)
        {
            Console.WriteLine("enter the number");
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Enter the valid input");
            return TermintaionCheck(num); 
        }
        static bool TermintaionCheck(int num)
        {
            if(num<0) 
                return false;
            
            return true;

        }
        static void FindGreater()
        {
            int number,greater=-1;
            while (ReadNumber(out number)) 
            {
                if (greater < number)
                {
                    greater = number;
                }

            }
            PrintFunction(greater);

        }
        static void PrintFunction(int great)
        {
            Console.WriteLine($"the greater number is {great}");

        }
        static void Main(string[] args)
        {
            FindGreater();
            
        }    
    }
}
