using Microsoft.VisualBasic.FileIO;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Day4Presidio
{
    internal class Program
    {

        static Doctor[] doctors = new Doctor[10]; 
        /// <summary>
        /// Validate the string
        /// </summary>
        /// <param name="input">String input</param>
        /// <param name="name">Sending the String in out</param>
        /// <returns>Return the validity as boolean</returns>
        static bool GetName(string input, out string name)
        {
            name = "";
            string pattern = @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch && input.Length>0)
            {
                name = input;
                return true;
            }
            return false;


        }
        /// <summary>
        /// Create doctor Object
        /// </summary>
        /// <param name="count">Count of doctor</param>
        /// <returns>REturn the reference</returns>
         static Doctor CreateDoctor (int count){
            Doctor doctor=new Doctor(count);
            Console.WriteLine("Enter name");
            string Name;
            while (!GetName(Console.ReadLine() ?? "",out Name))
            {
                Console.WriteLine("Enter the valid name");
            }
            doctor.Name = Trimmer(Name);

            Console.WriteLine("enter the Your Age");
            int Age;
            while (!int.TryParse(Console.ReadLine(), out Age)  || Age < 0 )
                Console.WriteLine("Enter the valid Non-Negative Age");

            doctor.Age = Age;
            int Experience;
            Console.WriteLine("enter the Year of experience");
            while (!int.TryParse(Console.ReadLine(), out Experience) || Experience < 0)
                Console.WriteLine("Enter the valid Non-Negative Experienec");
            doctor.Experience = Experience;

            Console.WriteLine("enter Your Qualification");
            string Qualification;
            while (!GetName(Console.ReadLine() ?? "", out Qualification))
            {
                Console.WriteLine("Enter the valid Qualfication");
            }
            doctor.Qualification = Trimmer(Qualification);
            Console.WriteLine("enter Your Specialization");
            string Specilization;
            while (!GetName(Console.ReadLine() ?? "", out Specilization))
            {
                Console.WriteLine("Enter the valid Specilization");
            }
            doctor.Speciality = Trimmer(Specilization);
            return doctor;

        }
        /// <summary>
        /// Trimm the extra space in string
        /// </summary>
        /// <param name="Data">Get the string</param>
        /// <returns>return the trimmed String</returns>
        static string Trimmer(string Data)
        {
            return Data.Trim();
        }
        /// <summary>
        /// Display The Doctors array
        /// </summary>
        /// <param name="TotalCount">Total count of the doctor</param>
        static void DisplayDoctors(int TotalCount)
        {
            for(int i=0;i<TotalCount; i++)
            {

                doctors[i].ShowDoctorsDetails();
                Console.WriteLine("------------------------------------------------------------");
            }
            HospitalManagement(TotalCount);

        }
        /// <summary>
        /// Create and store the doctor object in array
        /// </summary>
        /// <param name="DoctorsCount">get the doctor count</param>
        static void DoctorManager(int DoctorsCount )
        {
            doctors[DoctorsCount] = CreateDoctor(1001+DoctorsCount);
            HospitalManagement(DoctorsCount + 1);
        }
        /// <summary>
        /// Get the speciality and return the doctors with that speciality
        /// </summary>
        /// <param name="Speciality">Speciality of a doctor</param>
        /// <param name="Count">Total doctor count</param>
        static void SearchDoctorsForSpeciality(string Speciality,int Count)
        {
            int flag = 0;
            for (int i = 0; i < Count; i++)
            {
                flag = 1;
                if (doctors[i].Speciality == Speciality)
                {
                    
                    doctors[i].ShowDoctorsDetails();
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("No speciality found");
            }
            HospitalManagement(Count);

        }
        /// <summary>
        /// Recursive main function maintain the total hospital administration
        /// </summary>
        /// <param name="DoctorsCount">Totl count of doctor</param>
        static void HospitalManagement(int DoctorsCount)
        {
            Console.WriteLine("Enter the option\n 1.Add doctor \n 2.Show Doctors \n 3.Search Doctor for speciality");
            int option = int.Parse(Console.ReadLine() ?? "");
            switch (option)
            {
                case 1:
                    DoctorManager(DoctorsCount);
                    break;
                case 2:
                    DisplayDoctors(DoctorsCount);
                    break;
                case 3:
                    Console.WriteLine("Enter Speciality");
                    string Speciality = Console.ReadLine()??""; ;
                 
                    SearchDoctorsForSpeciality(Trimmer(Speciality), DoctorsCount);
                    break;
                default: 
                    Console.WriteLine("Terminated");
                    break;

            }
        }
        static void Main(string[] args)
        {
            HospitalManagement(0);
        }
    }
}
