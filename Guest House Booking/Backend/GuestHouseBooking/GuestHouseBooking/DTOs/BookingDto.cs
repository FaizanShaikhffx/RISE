using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class BookingCreateDto
    {
        [Required]
        public int GuestHouseId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int BedId { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
    }
    public class BookingDto
    {
        public int BookingId { get; set; }
        public string UserName { get; set; } // User's name
        public string GuestHouseName { get; set; }
        public string RoomName { get; set; }
        public string BedNumber { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class BookingRejectDto
    {
        [Required]
        public string Remarks { get; set; }
    }
}
