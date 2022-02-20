namespace SmartCookers_WebAPI.Dtos.User
{
    public class UserReadDto
    {
        public Guid id { get; set; }
        public string? first_Name { get; set; }
        public string? last_Name { get; set; }
        public string? nic { get; set; }
        public string? contactNo { get; set; }
        public List<string>? address { get; set; }
        public string? profile_Pic_Url { get; set; }
    
    }
}
