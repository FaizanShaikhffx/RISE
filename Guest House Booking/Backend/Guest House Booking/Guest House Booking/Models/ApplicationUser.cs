using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Guest_House_Booking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<AuditLog> AuditLogs { get; set; }

    }
}
