using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        public int GuestHouseId { get; set; }
        public GuestHouse GuestHouse { get; set; }

        [Required, MaxLength(50)]
        public string RoomName { get; set; }

        [Required]
        public string GenderAllowed { get; set; } // "Male", "Female", "Any"

        public ICollection<Bed> Beds { get; set; }

        public bool Deleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
