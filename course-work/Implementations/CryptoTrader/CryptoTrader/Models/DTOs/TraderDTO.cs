namespace CryptoTrader.Models.DTOs
{
    public class TraderDTO : BaseDTO
    {
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public int Age { get; set; }
        public string? Nationality { get; set; }
    }
}
