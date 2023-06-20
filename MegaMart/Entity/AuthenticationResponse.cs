using Microsoft.AspNetCore.Identity;

namespace MegaMart.Entity
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public IdentityUser User { get; set; }
        public string Role { get; set; }
        public DateTime Expiration { get; set; }
    }
}
