using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartCookers_WebAPI.Constants;
using SmartCookers_WebAPI.Dtos.Login;
using SmartCookers_WebAPI.Dtos.Register;
using SmartCookers_WebAPI.Dtos.Response;
using SmartCookers_WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto )
        {
           
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            
            if(user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user); // get all list of user roles 

                var authclaims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name,user.UserName),
                   new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };

                // add multiple roles to the claim 
                foreach(var role in userRoles)
                {
                    authclaims.Add(new Claim(ClaimTypes.Role,role));
                }

                var Authtoken = GetAuthenticationToken(authclaims);

                return Ok(new
                {
                    token=new JwtSecurityTokenHandler().WriteToken(Authtoken),
                    expiration = Authtoken.ValidTo
                });
            }
            return Unauthorized();
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

        [HttpPost]
        [Route("register-staff")]
        public async Task<IActionResult> RegisterStaff([FromBody] StaffRegisterDto staffRegisterDto)
        {
            var userExists = await _userManager.FindByEmailAsync(staffRegisterDto.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            SmartUser user = new()
            {
                Email = staffRegisterDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = staffRegisterDto.UserName
            };
            var result = await _userManager.CreateAsync(user, staffRegisterDto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation fail" });

            string userrole = "";

            switch (staffRegisterDto.Stafftype.ToUpper())
            {
                case "INVENTORYSTAFF": userrole = UserRoles.InventoryStaff; break;
                case "SALESSTAFF": userrole = UserRoles.SalesStaff; break;
                default: break;
            }


            if (!await _roleManager.RoleExistsAsync(userrole))
                await _roleManager.CreateAsync(new SmartIdentityRole() { Name = userrole });

            if (await _roleManager.RoleExistsAsync(userrole))
            {
                await _userManager.AddToRoleAsync(user, userrole);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

        }


        private JwtSecurityToken GetAuthenticationToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
              //  issuer: _configuration["JWT:ValidIssuer"],
               // audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
