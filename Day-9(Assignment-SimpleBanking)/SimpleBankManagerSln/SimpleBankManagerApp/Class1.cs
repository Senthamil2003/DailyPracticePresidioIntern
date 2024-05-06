using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagerApp
{
    public class CLass1
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var squaredNumbers = numbers.Where(n => n % 2==0);
            foreach(var number in squaredNumbers)
            {
                Console.WriteLine(number);
            }

        }

    }
   
}
