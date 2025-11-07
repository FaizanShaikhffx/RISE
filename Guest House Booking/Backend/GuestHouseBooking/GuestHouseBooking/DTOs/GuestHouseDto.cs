using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.DTOs
{
    public class GuestHouseCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
    }

    public class GuestHouseDto
    {
        public int GuestHouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
