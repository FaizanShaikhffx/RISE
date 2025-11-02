using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guest_House_Booking.Models
{
    public class Room : BaseEntity
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; } 
        public int TotalBeds { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(12, 2)")] 
        public decimal PricePerNight { get; set; }
        public int GuestHouseId { get; set; }
        public virtual ICollection<Bed> Beds { get; set; }
    }
}
