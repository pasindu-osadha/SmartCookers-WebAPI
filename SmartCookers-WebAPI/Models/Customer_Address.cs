

namespace SmartCookers_WebAPI.Models
{
    public class Customer_Address
    {
        public Guid Id { get; set; }
        public string? Customer_Address_Name { get; set; }

        public SmartUser?  SmartUser { get; set; }
    }
}
