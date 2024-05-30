namespace CryptoTrader.Models.Entities
{
    public class TraderData : BaseEntity
    {
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public int Age { get; set; }
        public string? Nationality { get; set; }
    }
}
