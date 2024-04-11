using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SixthProb
    {
        static void ReadUser()
        {
            string Sentance=Console.ReadLine()??"";
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
