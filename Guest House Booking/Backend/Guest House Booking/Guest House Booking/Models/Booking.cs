using System; 
using System.ComponentModel.DataAnnotations.Schema;

namespace Guest_House_Booking.Models
{
    public class Booking : BaseEntity
    {
        public int Id { get; set; }
        public int BedId { get; set; }
        public virtual Bed Bed { get; set; }

        public string UserId { get; set; } 
        public virtual ApplicationUser User { get; set; }


        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } 

        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }

        [Column(TypeName = "decimal(18, 2)")] 
        public decimal TotalPrice { get; set; }

        public string? Notes { get; set; }
        public string? RejectionReason { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
