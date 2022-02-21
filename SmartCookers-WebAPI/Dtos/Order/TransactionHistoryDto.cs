namespace SmartCookers_WebAPI.Dtos.Order
{
    public class TransactionHistoryDto
    {
        public Guid orderId { get; set; }
        public DateTime order_Date { get; set; }
        public string productName { get; set; }
        public int productQty { get; set; }
        public string? order_Status { get; set; }
        public decimal totalAmount { get; set; }
        public Guid userId { get; set; }
        public string outletName { get; set; }
    }
}
