using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FourthProb
    {
        static void ReadUser()
        {
            string User;
            int UserLenght;
            Console.WriteLine("Enter user name");
            while (!CheckValidUser(Console.ReadLine()??"", out User,out UserLenght)){
                Console.WriteLine("User name should not be empty");
            }

            PrintFunction(User, UserLenght);
        }
        static int Findlength(string User)
        {
            return User.Length;
        }
        
        static bool CheckValidUser(string User,out string Validuser,out int UserLenght)
        {
            if (Findlength(User) > 0)
            {
                Validuser = User;
                UserLenght = Findlength(User);
                return true;
            }

            Validuser = "";
            UserLenght = 0;
            return false;

        }
       
        static void PrintFunction(String User,int UserLength)
        {
            Console.WriteLine($"Welcome {User} your user name's lenght is {UserLength}");

        }
        static void Main(string[] args)
        {   
            ReadUser();
        }
    }
}
