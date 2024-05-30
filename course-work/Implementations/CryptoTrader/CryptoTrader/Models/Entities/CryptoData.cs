namespace CryptoTrader.Models.Entities
{
    public class CryptoData : BaseEntity
    {
        public required string Name { get; set; }
        public double Value { get; set; }
    }
}
