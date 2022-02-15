using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Dtos.Product
{
    public class ProductCreateDto
    {
        public string? Product_Name { get; set; }
        public string? Product_Description { get; set; }
        public decimal Product_UnitPrice { get; set; }
        public int? Product_Quantity { get; set; }
        public string? Product_Picture_Url { get; set; }
      
    }
}
