namespace AtmApplicationApp.Models.DTO
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public ErrorModel(int code, string message)
        {
            Message = message;
            Code = code;
        }
    }
}
