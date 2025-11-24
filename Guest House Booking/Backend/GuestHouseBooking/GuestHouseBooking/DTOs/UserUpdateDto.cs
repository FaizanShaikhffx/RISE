using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
