using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class BedCreateDto
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string BedNumber { get; set; }
    }
    public class BedDto
    {
        public int BedId { get; set; }
        public int RoomId { get; set; }
        public string BedNumber { get; set; }
    }
}
