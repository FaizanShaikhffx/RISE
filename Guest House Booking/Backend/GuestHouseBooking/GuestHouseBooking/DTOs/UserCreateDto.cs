using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class UserCreateDto
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, EmailAddress, MaxLength(120)]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; } 

        [Required]
        public string Role { get; set; } 

    }
}
