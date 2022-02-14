using System.ComponentModel.DataAnnotations;

namespace SmartCookers_WebAPI.Models
{
    public class Outlet:BaseModel
    {
       
        public Guid Id { get; set; }
        public string? Outlet_Name { get; set; }
        public string? Outlet_Address { get; set; }
        public string? Outlet_contactNo { get; set; }   
        

        public ICollection<Product_In_Outlet>? Product_In_Outlets { get; set; }
        public SmartUser? SmartUser { get; set; }
    }
}
