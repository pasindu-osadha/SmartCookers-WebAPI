namespace SmartCookers_WebAPI.Dtos.Product
{
    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public string? product_Name { get; set; }
        public string? product_Description { get; set; }
        public decimal product_UnitPrice { get; set; }
        public int? product_Quantity { get; set; }
        public string? product_Picture_Url { get; set; }
    }
}
