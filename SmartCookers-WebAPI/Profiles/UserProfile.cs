using AutoMapper;
using SmartCookers_WebAPI.Dtos.User;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<SmartUser, UserReadDto>()
                 .ForMember(dest => dest.id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.first_Name,
                opt => opt.MapFrom(src => src.First_Name))
                .ForMember(dest => dest.last_Name,
                opt => opt.MapFrom(src => src.Last_Name))
                 .ForMember(dest => dest.nic,
                opt => opt.MapFrom(src => src.NIC))
                .ForMember(dest=> dest.contactNo,
                opt=>opt.MapFrom(src=>src.PhoneNumber))
                .ForMember(dest => dest.address,
                opt => opt.MapFrom(src => src.Customer_Addresses.Select(c=>c.Customer_Address_Name).ToArray() ))
                .ForMember(dest => dest.profile_Pic_Url,
                opt => opt.MapFrom(src => src.Profile_Pic_Url));
                
        }
    }
}
