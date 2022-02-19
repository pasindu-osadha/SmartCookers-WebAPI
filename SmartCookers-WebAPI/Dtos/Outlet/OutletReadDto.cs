namespace SmartCookers_WebAPI.Dtos.Outlet
{
    public class OutletReadDto
    {
        public Guid Id { get; set; }
        public string? Outlet_Name { get; set; }
        public string? Outlet_Address { get; set; }
        public string? Outlet_contactNo { get; set; }
    }
}
