namespace AtmApplicationApp.CustomException
{
    public class RepositoryException:Exception
    {
        string message;
        public RepositoryException(string message) {
            this.message = message;
        }
        public override string Message => message;
    }
}
