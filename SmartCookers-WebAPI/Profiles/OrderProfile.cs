using AutoMapper;
using SmartCookers_WebAPI.Dtos.Order;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, TransactionHistoryDto>()
                .ForMember(dest => dest.orderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.order_Date, opt => opt.MapFrom(src => src.Order_Date.ToShortDateString()))
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Product_Orders.FirstOrDefault().Product_In_Outlet.Product.Product_Name))
                .ForMember(dest => dest.productQty, opt => opt.MapFrom(src => src.Product_Orders.FirstOrDefault().Product_Order_Qty))
                .ForMember(dest => dest.order_Status, opt => opt.MapFrom(src => src.Order_Status))
                .ForMember(dest => dest.totalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.SmartUser.Id))
                .ForMember(dest => dest.outletName, opt => opt.MapFrom(src => src.Product_Orders.FirstOrDefault().Product_In_Outlet.Outlet.Outlet_Name));
        }
    }
}


