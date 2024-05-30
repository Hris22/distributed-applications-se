namespace CryptoTrMVC.Models
{
    public class OrderViewModel : BaseViewModel
    {

        public  string Title { get; set; }
        public string? Description { get; set; }
        public int TraderId { get; set; }
        public int CryptoId { get; set; }
        public double Value { get; set; }
    }
}
