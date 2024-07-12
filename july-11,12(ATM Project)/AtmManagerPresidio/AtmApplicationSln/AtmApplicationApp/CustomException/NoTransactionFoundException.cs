namespace AtmApplicationApp.CustomException
{
    public class NoTransactionFoundException:Exception
    {
        string message;
        public NoTransactionFoundException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
