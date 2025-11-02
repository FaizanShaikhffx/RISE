using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; 

namespace Guest_House_Booking.Models
{
    public class GuestHouse : BaseEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image { get; set; } 
        public double Rating { get; set; }
        public int TotalRooms { get; set; }


        [Column(TypeName = "decimal(12, 2)")]
        public decimal PricePerNight { get; set; }

        public string Features { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        
    }
}
