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
        public string PasswordHash { get; set; } 

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Role { get; set; } 

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
