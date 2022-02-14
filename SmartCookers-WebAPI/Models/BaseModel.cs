namespace SmartCookers_WebAPI.Models
{
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; }= DateTime.Now;
        public DateTime? LastUpdatedDate { get; set; }=DateTime.Now;
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
