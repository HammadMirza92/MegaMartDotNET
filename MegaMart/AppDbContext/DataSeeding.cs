using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace MegaMart.AppDbContext
{
    public static class DataSeeding
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                DateTime currentDate = DateTime.Now;
                DateTime nextDate = currentDate.AddDays(5);

                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate(); // apply all migrations

                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

             
            }
        }
    }
}
