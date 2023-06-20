using MegaMart.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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
                 
                    var product = new Product()
                    {
                        Id = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        ProductName = "Demo product One",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image= "https://images.pexels.com/photos/2536965/pexels-photo-2536965.jpeg?cs=srgb&dl=pexels-suzy-hazelwood-2536965.jpg&fm=jpg",
                      /*  Price= 12.23,*/
                        /*Quantity= 0,*/
                        /*Stock = 22,*/
                        ProductType = Enums.ProductType.Variation,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addProduct = context.Product.Add(product).Entity;

                    var simpleproduct = new Product()
                    {
                        Id = Guid.Parse("54d70b9f-9a0b-4053-98e8-09b2f185860f"),
                        ProductName = "Simple Product",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://www.oberlo.com/media/1603969900-productphotog-2.jpg?w=1824&fit=max",
                        Price = 12.23,
                        Quantity = 0,
                        Stock = 22,
                        ProductType = Enums.ProductType.Variation,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct = context.Product.Add(simpleproduct).Entity;

                    /************ Variations ***************/

                    var colorVariation = new ProductVariations()
                    {
                        Id = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        ProductId = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        IsDeleted = false,
                    };

                    var addcolorVariation = context.ProductVariations.Add(colorVariation).Entity;
              
/*
                    var sizeVariation = new ProductVariations()
                    {
                        Id = Guid.Parse("25194487-87bf-469d-a8aa-4c9244cacd60"),
                        ProductId = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        IsDeleted = false,
                    };

                    var addsizeVariation = context.VariationAttributes.Add(sizeVariation).Entity;*/
                   

                    /************ Variation Options ***************/

                    var colorVariationOpt1 = new VariationOptions()
                    {
                        Id = Guid.Parse("18696463-3caf-4125-b58a-43d32c5a75be"),
                        Name = "Color",
                        Option = "Red",
                        StockQuantity = 5,
                        Price = 50,
                        VariationAttributeId = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        IsDeleted = false,
                    };

                    var addcolorVariationOpt1 = context.VariationOptions.Add(colorVariationOpt1).Entity;
                   

                    var colorVariationOpt2 = new VariationOptions()
                    {
                        Id = Guid.Parse("7eb386c0-ce1d-4ffa-8777-0b32b5f412c1"),
                        Name = "Color",
                        Option = "Green",
                        StockQuantity = 9,
                        Price = 80,
                        VariationAttributeId = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        IsDeleted = false,
                    };

                    var addcolorVariationOpt2 = context.VariationOptions.Add(colorVariationOpt2).Entity;
                    context.SaveChanges();
                }
            }
        }
    }
}
