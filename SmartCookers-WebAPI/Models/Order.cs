
namespace SmartCookers_WebAPI.Models
{
    public class Order : BaseModel
    {
        
        public Guid Id { get; set; }
        public DateTime Order_Date { get; set;}
        public string? Order_Status { get; set;}
        public string? Email_Status { get; set;} 
        public decimal TotalAmount { get; set;}

        public ICollection<Product_Order>? Product_Orders { get; set; }
        public SmartUser? SmartUser { get; set; }
    }
}
