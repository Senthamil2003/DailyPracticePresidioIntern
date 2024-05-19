namespace EmployeeManagerApi.Model
{
    public class ErrorModel
    {
        public int Code { get; set; }   
        public string Message { get; set; }
        public ErrorModel() {
            Code = 0;
            Message = string.Empty;
        }
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
