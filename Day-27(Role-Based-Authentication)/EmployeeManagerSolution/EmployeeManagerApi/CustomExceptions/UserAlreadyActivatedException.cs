namespace EmployeeManagerApi.CustomExceptions
{
    public class UserAlreadyActivatedException:Exception
    {
        string message;
        public UserAlreadyActivatedException(string msg)
        {
            message= msg;
        }
        public override string Message => message;
    }
}
