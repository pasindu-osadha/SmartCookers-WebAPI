

namespace SmartCookers_WebAPI.Models
{
    public class Product_In_Outlet:BaseModel
    {
     
        public Guid Id { get; set; }
        public int Available_qty { get; set; }
        

        public Product? Product { get; set; }
        public Outlet? Outlet { get; set; }
        public ICollection<Product_Order>? Product_Orders { get; set; }

    }
}
