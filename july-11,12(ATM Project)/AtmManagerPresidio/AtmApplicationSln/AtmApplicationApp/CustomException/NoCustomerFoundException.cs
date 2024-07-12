namespace AtmApplicationApp.CustomException
{
    public class NoCustomerFoundException:Exception
    {
        string message;
        public NoCustomerFoundException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
