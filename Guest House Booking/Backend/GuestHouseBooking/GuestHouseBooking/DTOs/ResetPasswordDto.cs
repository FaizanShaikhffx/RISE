using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class ResetPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Otp { get; set; }

        [Required, MinLength(6)]
        public string NewPassword { get; set; }
    }
}
