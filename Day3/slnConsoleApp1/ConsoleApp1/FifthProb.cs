using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FifthProb
    {
        static string ReadUser()
        {
            string User;
            
            
            while(!CheckValidUser(Console.ReadLine() ?? "", out User))
            {
                Console.WriteLine("User name or password should not be empty");
            }
            return User.Trim();

        }
        

        static bool CheckValidUser(string User, out string Validuser)
        {
            if (User.Length > 0)
            {
                Validuser = User;
                return true;
            }

            Validuser = "";
            return false;

        }
        static void Authentication(string User,String Password,int AttemtCount)
        {
            if(User=="ABC" && Password == "123")
            {
                Console.WriteLine($"Welcome {User}");
            }
            else
            {
                Console.WriteLine("User details wrong");
                LoginSystem(AttemtCount + 1);
            }


        }
        static void LoginSystem(int AttemtCount)
        {
            if (AttemtCount <3) {
                Console.WriteLine("Enter user name");
                string username = ReadUser();
                Console.WriteLine("Enter user Password");
                string password = ReadUser();
                Authentication(username, password,AttemtCount);

            }
            else
            {
                Console.WriteLine("Your credentials are not correct please login later");
            }
           

        }

       
        static void Main(string[] args)
        {

            LoginSystem(0);
        }

    }
}
