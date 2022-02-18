using AutoMapper;
using SmartCookers_WebAPI.Dtos.ProductInOutlet;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Profiles
{
    public class ProductInOutletProfile :Profile
    {
        public ProductInOutletProfile()
        {
            CreateMap<Product_In_Outlet, ProductInOutletReadDto>()
                .ForMember(dest=> dest.productInOutletId,
                opt=>opt.MapFrom(src=> src.Id))
                .ForMember(dest => dest.productId,
                opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.outletId,
                opt => opt.MapFrom(src => src.Outlet.Id))
                .ForMember(dest => dest.product_Name,
                opt => opt.MapFrom(src => src.Product.Product_Name))
                .ForMember(dest => dest.product_Description,
                opt => opt.MapFrom(src => src.Product.Product_Description))
                .ForMember(dest => dest.product_UnitPrice,
                opt => opt.MapFrom(src => src.Product.Product_UnitPrice))
                .ForMember(dest => dest.Avalable_Quantity,
                opt => opt.MapFrom(src => src.Available_qty))
                .ForMember(dest => dest.product_Picture_Url,
                opt => opt.MapFrom(src => src.Product.Product_Picture.FirstOrDefault().Product_Picture_Url));








        }

    }
}
