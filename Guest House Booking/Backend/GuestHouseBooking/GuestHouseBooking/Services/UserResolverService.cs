using System.Security.Claims;

namespace GuestHouseBooking.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor contextAccessor) {
            _httpContextAccessor = contextAccessor;
        }

        public int GetUserId() {
            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userIdString, out int userId)) {
                return userId; 
            }

            return 0;

        }


    }
}
