using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class RoomCreateDto
    {
        [Required]
        public int GuestHouseId { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public string GenderAllowed { get; set; } // "Male", "Female", "Any"
    }
    public class RoomDto
    {
        public int RoomId { get; set; }
        public int GuestHouseId { get; set; }
        public string RoomName { get; set; }
        public string GenderAllowed { get; set; }
    }
}
