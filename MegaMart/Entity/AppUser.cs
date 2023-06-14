using Microsoft.AspNetCore.Identity;

namespace MegaMart.Entity
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
