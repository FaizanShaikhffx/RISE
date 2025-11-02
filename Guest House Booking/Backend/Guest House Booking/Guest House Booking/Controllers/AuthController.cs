using Guest_House_Booking.Dtos;
using Guest_House_Booking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Guest_House_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              RoleManager<IdentityRole> roleManager,
                              IConfiguration configuration
                              ) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto ) {
            
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var user = new ApplicationUser
            {

                Name = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Address = registerDto.Address,

            };


            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) {
                return BadRequest(result.Errors); 
            }
            await userManager.AddToRoleAsync(user, "User"); 

            return Ok(new { Message = "User registered successfully!"});

        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)  {
            var result = await signInManager.CheckPasswordSignInAsync(
                    await userManager.FindByEmailAsync(loginDto.Email),
                    loginDto.Password,
                    false
            );

            if (!result.Succeeded) {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            var user = await userManager.FindByEmailAsync(loginDto.Email);
            var token = await GenerateToken(user);

            return Ok(new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Name = user.Name
            });

        }

        private async Task<string> GenerateToken(ApplicationUser user) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userRoles = await userManager.GetRolesAsync(user);
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name)
            };

            foreach(var role in userRoles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(24), 
            signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
