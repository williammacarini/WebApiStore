namespace Store.Service.DTOs
{
    public class PurchaseDetailDTO
    {
        public int PurchaseId { get; set; }
        public string User { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
    }
}
