using MegaMart.Entity;
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

                if (!context.Product.Any())
                {
                    var category = new Category()
                    {
                        Id = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        CategoryName = "Beauty",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        IsDeleted = false,
                    };
                    var addcat = context.Categories.Add(category).Entity;
                    context.SaveChanges();
                    var attribute = new VariationAttribute()
                    {
                        Id = Guid.Parse("f3b9d692-1197-42d3-b72a-3aad5206c7cb"),
                        Name = "color",
                        IsDeleted = false,
                    };
                    var addAttribute = context.VariationAttributes.Add(attribute).Entity;
                    context.SaveChanges();
                    var product = new Product()
                    {
                        Id = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        ProductName = "Demo product One",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image= "https://images.pexels.com/photos/2536965/pexels-photo-2536965.jpeg?cs=srgb&dl=pexels-suzy-hazelwood-2536965.jpg&fm=jpg",
                        Price= 12.23,
                        Quantity= 0,
                        Stock = 22,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addProduct = context.Product.Add(product).Entity;
                    context.SaveChanges();

                    var productAtt1 = new ProductAttribute()
                    {
                        Id = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        Values="Red",
                        ProductId = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        AttributeId = Guid.Parse("f3b9d692-1197-42d3-b72a-3aad5206c7cb"),
                        IsDeleted = false,
                    };

                    var addProductAtt = context.ProductAttributes.Add(productAtt1).Entity;
                    var productAtt2 = new ProductAttribute()
                    {
                        Id = Guid.Parse("1c758fd2-b542-48d3-9eef-0da62f4285e4"),
                        Values = "Green",
                        ProductId = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        AttributeId = Guid.Parse("f3b9d692-1197-42d3-b72a-3aad5206c7cb"),
                        IsDeleted = false,
                    };

                    var addProductAtt2 = context.ProductAttributes.Add(productAtt2).Entity;
                    context.SaveChanges();
                }
            }
        }
    }
}
