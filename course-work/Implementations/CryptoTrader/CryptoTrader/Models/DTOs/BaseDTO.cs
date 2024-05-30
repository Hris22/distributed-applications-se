namespace CryptoTrader.Models.DTOs
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn
        {
            get; set;

        }
    }
}
