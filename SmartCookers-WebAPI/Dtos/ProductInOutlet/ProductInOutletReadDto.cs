namespace SmartCookers_WebAPI.Dtos.ProductInOutlet
{
    public class ProductInOutletReadDto
    {
        public Guid productInOutletId { get; set; }
        public Guid productId { get; set; }
        public Guid outletId{get; set; }
        public string? product_Name { get; set; }
        public string? product_Description { get; set; }
        public decimal product_UnitPrice { get; set; }
        public int? Avalable_Quantity { get; set; }
        public string? product_Picture_Url { get; set; }
    }
}
