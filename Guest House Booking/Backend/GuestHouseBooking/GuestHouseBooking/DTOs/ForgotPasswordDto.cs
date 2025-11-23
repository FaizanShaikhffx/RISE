using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class ForgotPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
