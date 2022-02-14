

namespace SmartCookers_WebAPI.Models
{
    public class Product_Picture:BaseModel
    {
     
        public Guid Id { get; set; }
        public string? Product_Picture_Url { get; set; }
        

        public Product? Product { get; set; }
    }
}
