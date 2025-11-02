using System.Collections.Generic;

namespace Guest_House_Booking.Models
{
    public class Bed : BaseEntity
    {
        public int Id { get; set; }
        public string BedNumber { get; set; } 
        public string Type { get; set; }

        public int RoomId { get; set; } 

        public virtual Room Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
