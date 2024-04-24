using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
    internal class SixthProb
    {
        static bool GetSentance(string input, out string data)
        {
            data = "";
            string pattern = @"^[a-zA-Z,]+$";

            input = input.Trim();
            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch && input.Length > 0)
            {
                data = input;
                return true;
            }
            return false;


        }
        static void ReadUser()
        {
            Console.WriteLine("Enter the Word with comma");
            string Sentance;
            while (!GetSentance(Console.ReadLine() ?? "", out Sentance))
            {
                Console.WriteLine("Enter the valid sentance");
            }
            SplitSentance(Sentance);
            
            
        }

        static void SplitSentance(string Scentance)
        {
            string[] words= Scentance.Split(',');
            Dictionary<string, int> wordcount = new Dictionary<string, int>();
            int minct = 100001;
            foreach (string word in words)
            {
                int VowelCount = 0;
                foreach (char Letter in word)
                {
                    
                    if (isVowel(Letter))
                    {
                        VowelCount++;
                    }
                  

                }
              
                if (VowelCount < minct)
                {
                    minct = VowelCount;
                }
                wordcount[word] = VowelCount;




            }
            CalculateLeastVowel(wordcount, minct);
        }
        static void CalculateLeastVowel(Dictionary<string, int> wordStore,int min)
        {
            foreach (string key in wordStore.Keys)
            {
                if(wordStore[key] == min)
                    PrintFunction(key, min);

            }


        }

        static void PrintFunction( string word,int count)
        {
            Console.WriteLine($"the word is {word} and count is {count}");
        }





        static bool isVowel(char letter)
        {
          
            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter =='u') return true;
            return false;

        }
  
     

       
        static void Main(string[] args)
        {

            ReadUser();
        }

    }
}
