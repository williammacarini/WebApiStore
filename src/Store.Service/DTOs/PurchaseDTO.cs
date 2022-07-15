﻿namespace Store.Service.DTOs
{
    public class PurchaseDTO
    {
        public string Code { get; set; }
        public string Document { get; set; }
        public int PurchaseId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
