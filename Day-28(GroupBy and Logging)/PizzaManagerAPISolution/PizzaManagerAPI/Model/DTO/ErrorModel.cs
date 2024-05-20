namespace PizzaManagerAPI.Model.DTO
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } 
        public ErrorModel(int code, string message)
        {
            StatusCode = code;
            Message = message;
        }
    }
}
