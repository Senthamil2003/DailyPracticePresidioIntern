using RequestTrackerModelLibrary;

namespace Day5App
{
    internal class Program
    {
        void switchHandler()
        {
            int option=int.Parse(Console.ReadLine()??"");
            switch(option)
            {
                case 1:
                case 2:
                    Console.WriteLine("hi 1 and 2");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;

                default:
                    Console.WriteLine("nope");
                    break;
            }
        }
        void CountThreeDigitRepeatNummber()
        {
            int[] a = { 111, 211, 222, 444, 555 };
            int count = 0;
            for(int i=0;i<a.Length; i++)
            {
                //Console.WriteLine("{0} {1} {2}", (a[i] / 10)%10, a[i] / 100, a[i] % 10);

                if (a[i] / 100 == (a[i]/10)%10 && a[i] / 100 == a[i] % 10)
                {
                    count++;

                }
               
            }
            Console.WriteLine($"Repeating digit count {count}");
        }
        static void Main(string[] args)
        {
            Program data=new Program();
            Console.WriteLine("Hello, World!");
            data.CountThreeDigitRepeatNummber();


        }
    }
}
