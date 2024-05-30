using CryptoTrader.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoTrader.Data
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
        {
            
        }
        public DbSet<CryptoData> CryptoDatas { get; set; }
        public DbSet<OrderData> OrderDatas { get; set; }
        public DbSet<TraderData> TraderDatas { get; set; }
    }
}
