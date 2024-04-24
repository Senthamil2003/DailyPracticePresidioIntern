namespace HospitalTrackerBLLibrary
{
   
    public class Class1
    {
        static int Hi()
        {
            try
            {

                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                return a / b;
            }
            catch (Exception e) {
                Console.WriteLine("koko");
            }
            finally
            {
                Console.WriteLine("poda");

            }
            return 0;
        }
        static void Main(string[] args)
        {
          


        }
    }


    }
    

