namespace ProductApp.Service
{
    public class NoProductFoundException:Exception
    {
        string message;
        public NoProductFoundException(string message)
        {
            this.message = message;
        }
        public override string Message =>message;
    }
}
