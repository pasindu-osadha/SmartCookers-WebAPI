using AutoMapper;
using SmartCookers_WebAPI.Dtos.Product;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>()
                .ForMember(
                    des => des.Product_Picture_Url, opt=> opt.MapFrom(src => src.Product_Picture.FirstOrDefault().Product_Picture_Url)
                );

            CreateMap<ProductCreateDto, Product>()
                .ForMember(
                dest => dest.Product_Picture,
                opt => opt.MapFrom(src => new List<Product_Picture> { new Product_Picture { Product_Picture_Url = src.Product_Picture_Url } } ));
        }
            
    }
}
