namespace ProductApp.Service
{
    public class ErrorResponse
    {
       
        public string Message { get; set; }
        public int Id { get; set; }
        public ErrorResponse(string message, int id)
        {
            Message = message;
            Id = id;
        }

    }

}
