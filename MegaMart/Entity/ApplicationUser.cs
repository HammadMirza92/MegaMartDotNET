using Microsoft.AspNetCore.Identity;

namespace MegaMart.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
