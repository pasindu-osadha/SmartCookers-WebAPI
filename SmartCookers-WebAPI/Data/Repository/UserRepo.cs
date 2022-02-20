using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.User;
using SmartCookers_WebAPI.Models;
using System.Linq;

namespace SmartCookers_WebAPI.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly SmartDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<SmartUser> _userManager;

        public UserRepo(SmartDbContext context, IMapper mapper, UserManager<SmartUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task <UserReadDto> GetuserDetailsById(Guid id)
        { 
            var result = (from U in _context.Users
                          from A in _context.Customer_Addresses
                          where (U.Id == A.SmartUser.Id && A.SmartUser.Id == id)

                          select new SmartUser
                          {
                              Id = U.Id,
                              UserName = U.UserName,
                              Customer_Addresses = U.Customer_Addresses,
                              First_Name=U.First_Name,
                              Last_Name=U.Last_Name,
                              NIC=U.NIC,
                              PhoneNumber=U.PhoneNumber,
                              Profile_Pic_Url=U.Profile_Pic_Url
                          
                          }
                   ).FirstOrDefault();

            return _mapper.Map<UserReadDto>(result);
        }
    }
}
