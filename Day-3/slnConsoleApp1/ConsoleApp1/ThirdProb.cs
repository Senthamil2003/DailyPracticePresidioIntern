using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ThirdProb
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
            if (num < 0)
                return false;

            return true;

        }
        static bool SevenDivisorChecker(int Number)
        {
            if (Number % 7 == 0)
            {
                return true;
            }
            return false;
        }
        static void AverageOfNumbersDivisibleBySeven()
        {
            int Number, Sum=0,TotalNumbers=0;
            while (ReadNumber(out Number))
            {
                if (SevenDivisorChecker(Number))
                {
                    Sum += Number;
                    TotalNumbers++;
                }

            }
            if(TotalNumbers == 0)
            {
                Console.WriteLine("There is no number is Divisible by 7");
            }

            PrintFunction(TotalNumbers,Sum);

        }
        static void PrintFunction(int TotalNumber,int Sum)
        {

            Console.WriteLine($"The Average of Number Divisible by 7 is {(double)Sum/TotalNumber}");

        }
        static void Main(string[] args)
        {
            AverageOfNumbersDivisibleBySeven();

        }
    
    }
}
