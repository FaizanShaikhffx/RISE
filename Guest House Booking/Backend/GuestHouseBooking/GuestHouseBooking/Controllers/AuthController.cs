using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuestHouseBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        public AuthController(ApplicationDbContext context, IEmailService emailService, IConfiguration config) {
            _context = context;
            _emailService = emailService;
            _config = config;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email && !u.Deleted);

            if (user == null) {
                return Unauthorized("Invalid Credentials.");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash)) {
                return Unauthorized("Invalid Credentials.");
            }

            if (!user.IsActive) {
                return Unauthorized("Account is inactive.");
            }


            var token = GenerateJwtToken(user);

            var response = new LoginResponseDto
            {
                Token = token,
                UserName = user.UserName,
                Role = user.Role,
                Gender = user.Gender
            };

            return Ok(response);

        }

        [HttpPost("create-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {

            if (await _context.Users.AnyAsync(u => u.Email == userCreateDto.Email))
            {
                return BadRequest("User is already in use.");
            }

            string randomPassword = Path.GetRandomFileName().Replace(".", "").Substring(0, 10);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(randomPassword);

            var user = new User
            {
                UserName = userCreateDto.UserName,
                Email = userCreateDto.Email,
                Gender = userCreateDto.Gender,
                Role = userCreateDto.Role,
                PasswordHash = hashedPassword,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = 0
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var emailBody = $"Welcome, {user.UserName}!<br><br>" +
                            $"Your account has been created for the Guesthouse Booking system.<br>" +
                            $"Your username is: <b>{user.Email}</b><br>" +
                            $"Your temporary password is: <b>{randomPassword}</b><br><br>" +
                            $"Please log in and change your password.";

            await _emailService.SendEmailAsync(user.Email, "Your New Guesthouse Account", emailBody);

                _context.EmailNotificationLogs.Add(new EmailNotificationLog
                {
                    ToEmail = user.Email,
                    Subject = "Your New Guesthouse Account",
                    SentDate = DateTime.UtcNow,
                });

                await _context.SaveChangesAsync();

                return Ok(new { message = $"User {user.UserName} created and email sent." });
        }


            private string GenerateJwtToken(User user) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("username", user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        
        }

        [HttpPost("setup-first-admin")]
        [AllowAnonymous]
        public async Task<IActionResult> SetupFirstAdmin([FromBody] LoginRequestDto adminDetails) {

            if (await _context.Users.AnyAsync(u => u.Role == "Admin")) {
                return BadRequest("An admin account already exists.");
            }

            var user = new User
            {
                UserName = "Admin",
                Email = adminDetails.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminDetails.Password),
                Role = "Admin",
                Gender = "N/A",
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedBy = 1
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("First admin account created successfully.");

        }

       
        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && !u.Deleted);
            if (user == null)
            {
                
                return Ok(new { message = "If an account with this email exists, an OTP has been sent." });
            }

            var otp = new Random().Next(100000, 999999).ToString();

            var passwordResetOtp = new PasswordResetOtp
            {
                Email = dto.Email,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(10) 
            };

            _context.PasswordResetOtps.Add(passwordResetOtp);
            await _context.SaveChangesAsync();

            try
            {
                var emailBody = $"Your password reset OTP is: <b>{otp}</b><br><br>" +
                                $"This OTP will expire in 10 minutes.";
                await _emailService.SendEmailAsync(dto.Email, "Your Password Reset OTP", emailBody);

                _context.EmailNotificationLogs.Add(new EmailNotificationLog
                {
                    ToEmail = dto.Email,
                    Subject = "Your Password Reset OTP",
                    SentDate = DateTime.UtcNow
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send OTP email: {ex.Message}");
            }

            return Ok(new { message = "If an account with this email exists, an OTP has been sent." });
        }


        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var otpEntry = await _context.PasswordResetOtps
                .FirstOrDefaultAsync(o => o.Email == dto.Email && o.Otp == dto.Otp);

            if (otpEntry == null)
            {
                return BadRequest(new { message = "Invalid or expired OTP." });
            }

            if (otpEntry.ExpiryTime < DateTime.UtcNow)
            {
                _context.PasswordResetOtps.Remove(otpEntry); 
                await _context.SaveChangesAsync();
                return BadRequest(new { message = "Invalid or expired OTP." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Invalid request." });
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            _context.PasswordResetOtps.Remove(otpEntry);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Password reset successful. You can now log in." });
        }
    }
}
