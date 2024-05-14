namespace DoctorClinicManagerWebApi.CustomException
{
    public class NullValueException:Exception
    {
        string message;
        public NullValueException()
        {
            message = "Null Value found for the request";
        }
        public override string Message => message;

    }
}
