namespace EmployeeManagerApi.CustomExceptions
{
    public class NoEmployeeFoundException:Exception
    {
        string message;
        public NoEmployeeFoundException()
        {
            message = "No Employee Found for the given Id";
        }
        public override string Message => message;

    }
}
