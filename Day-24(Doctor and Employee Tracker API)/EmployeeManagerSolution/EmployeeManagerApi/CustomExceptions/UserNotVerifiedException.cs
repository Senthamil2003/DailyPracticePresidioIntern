namespace EmployeeManagerApi.CustomExceptions
{
    public class UserNotVerifiedException:Exception
    {
        string message;
        public UserNotVerifiedException()
        {
            message = "User not Verified By the admin";
        }
        public override string Message =>message;
    }
}
