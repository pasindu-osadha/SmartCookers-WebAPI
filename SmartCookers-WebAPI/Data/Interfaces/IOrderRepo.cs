using SmartCookers_WebAPI.Dtos.Order;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Data.Interfaces
{
    public interface IOrderRepo
    {
        Task<bool> CreateOrder(OrderCreateDto orderCreateDto, SmartUser user);
    }
}
