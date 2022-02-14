

namespace SmartCookers_WebAPI.Models
{
    public class Product_Order:BaseModel
    {
 
        public Guid Id { get; set; }
        public int Product_Order_Qty { get; set; }
        public decimal Product_Order_Amount { get; set; }


        public Product_In_Outlet? Product_In_Outlet { get; set; }
        public Order? Order { get; set; }
    }
}
