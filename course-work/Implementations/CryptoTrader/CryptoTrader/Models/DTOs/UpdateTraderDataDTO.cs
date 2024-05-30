namespace CryptoTrader.Models.DTOs
{
    public class UpdateTraderDataDTO
    {
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public int Age { get; set; }
        public string? Nationality { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
