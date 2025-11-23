using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.Models
{
    public class Bed
    {
        public int BedId { get; set; }

        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required, MaxLength(20)]
        public string BedNumber { get; set; }

  
        public string Status { get; set; } = "Available";

        public bool Deleted { get; set; } = false;
    }
}
