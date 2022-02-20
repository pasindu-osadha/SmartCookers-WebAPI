using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.User;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo=repo;
        }

        [HttpGet]
        [Route("/GetuserDetailsById/{id}")]

        public async Task< ActionResult<UserReadDto>> GetuserDetails(Guid id)
        {
            var result = await _repo.GetuserDetailsById(id);
            if(result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
