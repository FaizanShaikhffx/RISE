using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, EmailAddress, MaxLength(120)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // We will store the HASH, not the password

        [Required]
        public string Gender { get; set; } // Male / Female

        [Required]
        public string Role { get; set; } // We will manually set this to "Admin" or "User"

        [Required]
        public bool IsActive { get; set; } = true;

        // Audit Fields
        public bool Deleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
