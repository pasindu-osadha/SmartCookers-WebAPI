using Microsoft.AspNetCore.Identity;

namespace SmartCookers_WebAPI.Models
{
    public class SmartUser : IdentityUser<Guid>
    {
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? NIC { get; set; }
        public string? Profile_Pic_Url { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }



        public ICollection<Outlet>? Outlets { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Customer_Address>? Customer_Addresses { get; set; }
    }
}
