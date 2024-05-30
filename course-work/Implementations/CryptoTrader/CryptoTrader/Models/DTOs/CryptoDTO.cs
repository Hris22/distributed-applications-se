namespace CryptoTrader.Models.DTOs
{
    public class CryptoDTO : BaseDTO
    {
        public required string Name { get; set; }
        public double Value { get; set; }
    }
}
