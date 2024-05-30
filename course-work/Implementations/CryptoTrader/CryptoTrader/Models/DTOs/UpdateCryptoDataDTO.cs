namespace CryptoTrader.Models.DTOs
{
    public class UpdateCryptoDataDTO
    {
        public required string Name { get; set; }
        public double Value { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
