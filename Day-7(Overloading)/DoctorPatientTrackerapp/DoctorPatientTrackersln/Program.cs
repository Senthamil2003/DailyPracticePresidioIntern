namespace DoctorPatientTrackersln
{
    public class Sample<T>
    {
       private T[] arr = new T[100];

   // Define the indexer to allow client code to use [] notation.
   public T this[int i]
   {
      get => arr[i];
      set => arr[i] = value;
   }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Sample<string> sample = new Sample<string>();
            sample[0] = "hello";
            sample[1] = "bello";
            Console.WriteLine(sample[0] + sample[1]);

            ;
        }
    }
}
