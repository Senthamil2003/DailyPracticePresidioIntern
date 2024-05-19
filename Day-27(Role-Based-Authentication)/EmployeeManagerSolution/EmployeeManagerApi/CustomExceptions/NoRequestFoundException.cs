namespace EmployeeManagerApi.CustomExceptions
{
    public class NoRequestFoundException:Exception
    {
        string message;
        public NoRequestFoundException(string value)
        {
            message = value;
        }
        public override string Message => message;
    }
}
