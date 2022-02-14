using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartCookers_WebAPI.Constants;
using SmartCookers_WebAPI.Dtos.Register;
using SmartCookers_WebAPI.Dtos.Response;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<SmartUser> _userManager;
        private RoleManager<SmartIdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<SmartUser> userManager, RoleManager<SmartIdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register-Customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegisterDto customerRegisterDto)
        {
            var userExists = await _userManager.FindByEmailAsync(customerRegisterDto.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            SmartUser user = new()
            {
                Email = customerRegisterDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = customerRegisterDto.UserName
            };
            var result = await _userManager.CreateAsync(user, customerRegisterDto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation fail" });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
                await _roleManager.CreateAsync(new SmartIdentityRole() { Name = UserRoles.Customer }); 

            if (await _roleManager.RoleExistsAsync(UserRoles.Customer))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Customer);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

        }

    }
}
