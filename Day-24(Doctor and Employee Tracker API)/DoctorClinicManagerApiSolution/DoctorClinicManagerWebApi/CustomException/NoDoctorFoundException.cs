namespace DoctorClinicManagerWebApi.CustomException
{
    public class NoDoctorFoundException:Exception
    {
        string message;
        public NoDoctorFoundException() {
            message = "No doctors found for the give request";
        }
        public override string Message => message;
    }
}
