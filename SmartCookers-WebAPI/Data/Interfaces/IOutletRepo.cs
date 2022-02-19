using SmartCookers_WebAPI.Dtos.Outlet;

namespace SmartCookers_WebAPI.Data.Interfaces
{
    public interface IOutletRepo
    {
        bool CreateOutlet(OutletCreateDto outletCreateDto );
    }
}
