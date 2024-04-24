using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day4Presidio
{
    internal class Task2
    {
        /// <summary>
        /// validate the 16 digit card number
        /// </summary>
        /// <param name="input">getting string input</param>
        /// <param name="name">sending output as string</param>
        /// <returns>return boolean value</returns>
        static bool ValidateCardno(string input, out string value)
        {
            value = "";
            string pattern = @"^[0-9\s]+$";
            input = input.Trim();

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch && input.Length == 16)
            {
                value = input;
                return true;
            }
            return false;


        }
        /// <summary>
        /// convert charecter to integer
        /// </summary>
        /// <param name="value">taking character value</param>
        /// <returns>return integer value</returns>
        static int integerConverter(char value)
        {
            string data=value.ToString();
            return int.Parse(data);

        }
        /// <summary>
        /// getting the integer and make it single digit by adding digit
        /// </summary>
        /// <param name="value">taking integer</param>
        /// <returns>return sum of digit</returns>
        static int integerSum(int value)
        {
            int sum = 0;
            while (value > 0)
            {
                sum += value%10;
                value /= 10;
            }
            return sum;
        }
        /// <summary>
        /// if index is even it remains or else multiply by 2
        /// </summary>
        /// <param name="cardValue">get string cardvalue</param>
        /// <returns>return total card sum</returns>
        static int OddEvenCalculation(string cardValue)
        {
            int totalSum = 0;
            for(int i = 0; i <cardValue.Length; i++) {
                if (i % 2 == 0)
                {
                   
                    totalSum += integerConverter(cardValue[i]);
                }
                else
                {
                    
                    totalSum += integerSum(integerConverter(cardValue[i])*2);

                }

                
            }
            return totalSum;
        }
        /// <summary>
        /// get the card number string
        /// </summary>
        /// <returns>reversed string</returns>
        static string GetAndReverseCardNumber()
        {
            string cardNo;
            Console.WriteLine("Enter 16 digit Card");
            while (!ValidateCardno(Console.ReadLine() ?? "", out cardNo))
            {
                Console.WriteLine("Enter the valid Card number");
            }
            return ReverseTheCardNumber(cardNo);



        }
        /// <summary>
        /// reverse the card number
        /// </summary>
        /// <param name="Card">take the string cardnumber</param>
        /// <returns>return reversed number</returns>
        static string ReverseTheCardNumber(string Card)
        {
            return new string(Card.Reverse().ToArray());


        }
        /// <summary>
        /// valid checker
        /// </summary>
        /// <param name="sum">get integer sum</param>
        /// <returns>return boolean</returns>
        static bool ValidateCard(int sum)
        {
            return sum%10 == 0;

        }

        static void Main(string[] args)
        {
            string cardValue=GetAndReverseCardNumber();
            Console.WriteLine(cardValue);
            int totalSum = OddEvenCalculation(cardValue);
            Console.WriteLine(totalSum);
            if (ValidateCard(totalSum))
            {
                Console.WriteLine("Card is valid");
            }
            else
            {
                Console.WriteLine("Card Not Valid");
            }

           
        }
    }
}
