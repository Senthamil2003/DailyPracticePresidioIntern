using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5App
{
   
    internal class CowAndBull
    {
        static bool StringValidator(string input, out string name)
        {
            name = "";
            string pattern = @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch && input.Length > 0 && input.Length==4)
            {
                name = input;
                return true;
            }
            return false;


        }
        string GetString()
        {
            
            string Name;
            while (!StringValidator(Console.ReadLine() ?? "", out Name))
            {
                Console.WriteLine("Enter the valid name");
            }
            return Name;


        }
        int IntChecker()
        {

            int Num;
            while (!int.TryParse(Console.ReadLine(), out Num))
                Console.WriteLine("Enter the valid Id");
            return Num;


        }
        int CalculateCow(string givenString ,string guess)
        {
            int ct = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (givenString[i] == guess[i])
                {
                    ct++;
                }
            }
            return ct;


        }
        int CalculateBull(string givenString ,string guess)
        {
                int ct = 0;
                for(int i = 0;i < guess.Length;i++)
                {
                    for(int j = 0; j < guess.Length; j++)
                    {
                        if (i != j)
                        {
                            if (givenString[i] == guess[j])
                            {
                                ct++;
                            }
                        }

                    }
                }
                return ct;


        }
       
        void Player2(string givenString)
        {
            string Guess;
            do
            {
                    Console.WriteLine("Give The Guess");
                    Guess = GetString();
                Console.WriteLine($"cow Count {CalculateCow(givenString,Guess)} BullCount {CalculateBull(givenString,Guess)}");

                } while (Guess != givenString);
            Console.WriteLine("Player 2 find the word");
        }
        void Player1() {
            Console.WriteLine("Enter the string to guess");
            string GivenString = GetString();
            Player2(GivenString);

        }
       
     
        static void Main(string[] args)
        {
            CowAndBull data = new CowAndBull();
            data.Player1();
           
        }
    }
}
