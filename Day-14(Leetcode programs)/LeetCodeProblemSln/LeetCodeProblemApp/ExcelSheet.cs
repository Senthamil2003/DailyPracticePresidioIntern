using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApp
{
 
    class ExcelSheet
    {
        static async  Task<string> ConvertToAlphabet(int number)
        {

            char alphabet = (char)('A' + number - 1);
            return alphabet.ToString();
        }
       async Task<string> ExcelColumn(int number)
        {
            string result="";
            while (number>0)
            {
              
                if (number<=26)
                {
                    result += await ConvertToAlphabet(number);
                    number = 0;
                }
                else
                {
                    int x = number % 26;
                    if (x == 0)
                    {
                        x = 26;

                    }
                    result +=await ConvertToAlphabet(1);
                    number -= x;
                    number/= 26;
                }

            }
            return result;
        }
        static async Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync("Enter the number to convert");
             int number=Convert.ToInt32(Console.ReadLine());
            ExcelSheet sheet = new ExcelSheet();
            string result=await sheet.ExcelColumn(number);
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);
            Console.WriteLine(reversedStr);


        }


    }

}
