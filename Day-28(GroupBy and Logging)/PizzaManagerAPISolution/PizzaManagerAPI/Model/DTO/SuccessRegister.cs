namespace PizzaManagerAPI.Model.DTO
{
    public class SuccessRegister
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Customer Customer { get; set; }
    }
}
