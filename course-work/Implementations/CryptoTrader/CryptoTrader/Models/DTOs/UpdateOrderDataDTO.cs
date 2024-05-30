﻿using CryptoTrader.Models.Entities;

namespace CryptoTrader.Models.DTOs
{
    public class UpdateOrderDataDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int TraderId { get; set; }
        public int CryptoId { get; set; }
        public double Value { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
