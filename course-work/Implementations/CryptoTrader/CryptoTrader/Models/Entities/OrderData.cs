namespace CryptoTrader.Models.Entities
{
    public class OrderData : BaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int TraderId { get; set; }
        public virtual TraderData? Traders { get; set; }
        public int CryptoId { get; set; }
        public virtual CryptoData? CryptoData { get; set; }
        public double ValueSum { get; set; }
    }
}
