namespace GuestHouseBooking.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public string Gender { get; set; } 
    }
}
