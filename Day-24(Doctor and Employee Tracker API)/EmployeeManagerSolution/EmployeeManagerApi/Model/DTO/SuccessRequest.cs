namespace EmployeeManagerApi.Model.DTO
{
    public class SuccessRequest
    {
        public int Code { get; set; }   
        public string Message { get; set; }
        public Request Request { get; set; }
    }
}
