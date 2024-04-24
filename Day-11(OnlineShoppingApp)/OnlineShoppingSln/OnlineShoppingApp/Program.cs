namespace OnlineShoppingApp
{
    internal class Program
    {
        public delegate T calDel<T>(T a,T b); 

        public void Calculate(calDel<int> cal)
        {
            Console.WriteLine(cal(1, 2));
            
        }
        int Add(int a,int b)
        {
            return a + b;
        }
        float Add(float a,float b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
           Program p=new Program();
            //p
            //p.Calculate(p.Add<int>);

            p.Add(1,2);
        }
    }
}
