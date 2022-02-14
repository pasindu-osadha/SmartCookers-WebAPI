

namespace SmartCookers_WebAPI.Models
{
    public class Product : BaseModel
    {
       
        public Guid Id { get; set; }
        public string? Product_Name { get; set; }
        public string? Product_Description { get; set; }
        public decimal Product_UnitPrice { get; set; }
        public int? Product_Quantity { get; set; }


        public SmartUser? SmartUser { get; set; }  
        public ICollection< Product_Picture>? Product_Picture { get; set; }
        public ICollection<Product_In_Outlet>? Product_In_Outlet { get; set; }
    }
}
