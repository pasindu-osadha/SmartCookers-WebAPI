using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.Order;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repo;
        private readonly UserManager<SmartUser> _userManager;

        public OrderController(IOrderRepo repo, UserManager<SmartUser> userManager)
        {
            _repo=repo;
            _userManager=userManager;
        }


        [HttpPost]
        [Route("CreateOrder")]
        public async Task< ActionResult> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var user =await _userManager.FindByIdAsync(orderCreateDto.UserId.ToString());
            if (user == null)
                return BadRequest();
;            var result = _repo.CreateOrder(orderCreateDto,user).Result;
            if (result == false)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        [Route("getTrasnsactionHistory/{id}")]
        public async Task<ActionResult> ViewTransactionHistoryAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRole = await _userManager.GetRolesAsync(user);
            if (user == null)
                return BadRequest();


            var result =await _repo.viewTransactionHistoryAsync(user,userRole[0]);
            return Ok(result);
        }

    }
}
