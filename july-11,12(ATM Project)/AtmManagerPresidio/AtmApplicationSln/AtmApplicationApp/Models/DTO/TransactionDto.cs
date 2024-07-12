namespace AtmApplicationApp.Models.DTO
{
    public class TransactionDto
    {
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionDescription { get; set; }


        public long AccountNumber { get; set; }
    }
}
