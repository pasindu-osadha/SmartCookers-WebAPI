using SmartCookers_WebAPI.Dtos.User;

namespace SmartCookers_WebAPI.Data.Interfaces
{
    public interface IUserRepo
    {
        Task <UserReadDto> GetuserDetailsById(Guid id);

    }
}
