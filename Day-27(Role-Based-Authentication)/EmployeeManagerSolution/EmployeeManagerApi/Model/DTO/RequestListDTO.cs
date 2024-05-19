namespace EmployeeManagerApi.Model.DTO
{
    public class RequestListDTO
    {
        public int RequestId { get; set; }
        public int  RaisedById { get; set; }
        public string Problem { get; set; }
        public string Status { get; set; }
        public DateTime RaisedDate { get; set; }

    }
}
