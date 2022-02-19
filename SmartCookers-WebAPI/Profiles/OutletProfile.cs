using AutoMapper;
using SmartCookers_WebAPI.Dtos.Outlet;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Profiles
{
    public class OutletProfile : Profile
    {
        public OutletProfile()
        {
            CreateMap<OutletCreateDto,Outlet>();
        }
    }
}
