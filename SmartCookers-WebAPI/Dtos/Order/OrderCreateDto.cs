namespace SmartCookers_WebAPI.Dtos.Order
{
    public class OrderCreateDto
    {
        public Guid productInOutletId { get; set; }
        public Guid productId { get; set; }
        public Guid outletId { get; set; }
        public Guid UserId { get; set; }
        public int product_Order_Qty { get; set; }
        public decimal totalAmount { get; set; }
    }
}
