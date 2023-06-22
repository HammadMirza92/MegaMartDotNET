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
                    var category1 = new Category()
                    {
                        Id = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        CategoryName = "Electronics",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        IsDeleted = false,
                    };
                    var addcat1 = context.Categories.Add(category1).Entity;
                 
                    var variationproduct1 = new Product()
                    {
                        Id = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        ProductName = "Demo product One",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image= "https://images.pexels.com/photos/2536965/pexels-photo-2536965.jpeg?cs=srgb&dl=pexels-suzy-hazelwood-2536965.jpg&fm=jpg",
                        /*Price= 12.23,*/
                        /*Quantity= 0,*/
                        /*Stock = 22,*/
                        ProductType = Enums.ProductType.Variation,
                        Featured = true,
                        OnSale = false,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addVariationproduct1 = context.Product.Add(variationproduct1).Entity;

                    var simpleproduct = new Product()
                    {
                        Id = Guid.Parse("54d70b9f-9a0b-4053-98e8-09b2f185860f"),
                        ProductName = "Simple Product",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://www.oberlo.com/media/1603969900-productphotog-2.jpg?w=1824&fit=max",
                        ProductType = Enums.ProductType.Simple,
                        Featured = true,
                        OnSale = true,
                        SKU = "SIMPLEONE",
                        Price = 12.23,
                        SalePrice = 10.23,
                        Quantity = 0,
                        Stock = 22,
                        StockStatus = Enums.StockStatus.InStock,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct = context.Product.Add(simpleproduct).Entity;

                    var simpleproduct2 = new Product()
                    {
                        Id = Guid.Parse("16d9ba61-1539-477d-8d03-19875632e9fc"),
                        ProductName = "Simple Product",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZHVjdHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80",
                        ProductType = Enums.ProductType.Simple,
                        Featured = true,
                        OnSale = false,
                        SKU = "SIMPLETWO",
                        Price = 15.13,
                        Quantity = 0,
                        Stock = 34,
                        StockStatus = Enums.StockStatus.InStock,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct2 = context.Product.Add(simpleproduct2).Entity;

                    var simpleproduct3 = new Product()
                    {
                        Id = Guid.Parse("82196f03-63f9-4888-80c9-5f5022e84b20"),
                        ProductName = "Simple Product",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://www.junglescout.com/wp-content/uploads/2021/01/product-photo-water-bottle-hero.png",
                        ProductType = Enums.ProductType.Simple,
                        Featured = true,
                        OnSale = true,
                        SKU = "SIMPLETHREE",
                        Price = 18.13,
                        SalePrice = 17.44,
                        Quantity = 0,
                        Stock = 65,
                        StockStatus = Enums.StockStatus.InStock,
                        CategoryId = Guid.Parse("f18a0fd6-cbd0-4cf7-9b1e-0c37b24b7396"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct3 = context.Product.Add(simpleproduct3).Entity;

                    /************ Variations ***************/

                    var colorVariation = new ProductVariations()
                    {
                        Id = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        ProductId = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        IsDeleted = false,
                    };

                    var addcolorVariation = context.ProductVariations.Add(colorVariation).Entity;                   

                    /************ Variation Options ***************/

                    var colorVariationOpt1 = new VariationOptions()
                    {
                        Id = Guid.Parse("18696463-3caf-4125-b58a-43d32c5a75be"),
                        Name = "Color",
                        Option = "Red",
                        VariationAttributeId = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        SKU="VARPRODUCTRED",
                        Price = 23.56,
                        SalePrice= 21.45,
                        StockQuantity = 5,
                        StockStatus = Enums.StockStatus.InStock,
                        IsDeleted = false,
                    };

                    var addcolorVariationOpt1 = context.VariationOptions.Add(colorVariationOpt1).Entity;
                   

                    var colorVariationOpt2 = new VariationOptions()
                    {
                        Id = Guid.Parse("7eb386c0-ce1d-4ffa-8777-0b32b5f412c1"),
                        Name = "Color",
                        Option = "Green",
                        VariationAttributeId = Guid.Parse("c3b33a51-f917-44f0-875c-2418c20886d1"),
                        SKU = "VARPRODUCTGREEN",
                        Price = 22.56,
                        SalePrice = 20.45,
                        StockQuantity = 8,
                        StockStatus = Enums.StockStatus.InStock,
                        IsDeleted = false,
                    };

                    var addcolorVariationOpt2 = context.VariationOptions.Add(colorVariationOpt2).Entity;
                    context.SaveChanges();


                    /* Second Product with category and variations*/

                    var category = new Category()
                    {
                        Id = Guid.Parse("3f4cf508-dbf0-453f-91cd-b76581fb343f"),
                        CategoryName = "Beauty",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        IsDeleted = false,
                    };
                    var addcat = context.Categories.Add(category).Entity;

                    var variationproduct2 = new Product()
                    {
                        Id = Guid.Parse("fb2de661-c885-4957-855f-85ce24ca8323"),
                        ProductName = "Face Wash",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://www.etonline.com/sites/default/files/styles/max_970x546/public/images/2021-02/best_rated_amazon_products_1280.jpg?h=c673cd1c&itok=XM7lepkW",
                        /*Price= 12.23,*/
                        /*Quantity= 0,*/
                        /*Stock = 22,*/
                        ProductType = Enums.ProductType.Variation,
                        Featured = true,
                        OnSale = false,
                        CategoryId = Guid.Parse("3f4cf508-dbf0-453f-91cd-b76581fb343f"),
                        IsDeleted = false,
                    };
                    var addvariationproduct2 = context.Product.Add(variationproduct2).Entity;

                    var simpleproduct4 = new Product()
                    {
                        Id = Guid.Parse("953f099e-2249-4da1-8e5e-38334c62dc4b"),
                        ProductName = "Simple Product 4",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://www.page.one/wp-content/uploads/2021/03/amazon-product-photos-10.jpg",
                        ProductType = Enums.ProductType.Simple,
                        Featured = true,
                        OnSale = true,
                        SKU = "SIMPLEFOUR",
                        Price = 12.23,
                        SalePrice = 10.23,
                        Quantity = 0,
                        Stock = 22,
                        StockStatus = Enums.StockStatus.InStock,
                        CategoryId = Guid.Parse("3f4cf508-dbf0-453f-91cd-b76581fb343f"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct4 = context.Product.Add(simpleproduct4).Entity;

                    var simpleproduct5 = new Product()
                    {
                        Id = Guid.Parse("2de8c0b6-aafb-4b3f-a447-c9a9e90ff8d0"),
                        ProductName = "Simple Product 5",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://media.istockphoto.com/id/1136422297/photo/face-cream-serum-lotion-moisturizer-and-sea-salt-among-bamboo-leaves.jpg?s=612x612&w=0&k=20&c=mwzWVrDvJTkHlVf-8RL49Hs5xjuv1TrYcBW4DnWVt-0=",
                        ProductType = Enums.ProductType.Simple,
                        Featured = true,
                        OnSale = false,
                        SKU = "SIMPLEFIVE",
                        Price = 15.13,
                        Quantity = 0,
                        Stock = 34,
                        StockStatus = Enums.StockStatus.InStock,
                        CategoryId = Guid.Parse("3f4cf508-dbf0-453f-91cd-b76581fb343f"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct5 = context.Product.Add(simpleproduct5).Entity;

                    var simpleproduct6 = new Product()
                    {
                        Id = Guid.Parse("9ac22038-3134-4fb8-9fd7-a0efd8e6c8fa"),
                        ProductName = "Simple Product 6",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        ShortDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Image = "https://media.istockphoto.com/id/1163013366/photo/natural-cosmetics.jpg?s=612x612&w=0&k=20&c=zuj4jsweHCRUtxtZTF1PV6NaA0OF4OIoKjrmkK3PuEo=",
                        ProductType = Enums.ProductType.Simple,
                        Featured = true,
                        OnSale = true,
                        SKU = "SIMPLESix",
                        Price = 18.13,
                        SalePrice = 17.44,
                        Quantity = 0,
                        Stock = 65,
                        StockStatus = Enums.StockStatus.InStock,
                        CategoryId = Guid.Parse("3f4cf508-dbf0-453f-91cd-b76581fb343f"),
                        IsDeleted = false,
                    };
                    var addsimpleproduct6 = context.Product.Add(simpleproduct6).Entity;

                    /************ Variations ***************/

                    var colorVariation1 = new ProductVariations()
                    {
                        Id = Guid.Parse("23dd43b1-9880-4ef1-809f-cbb8e26cdbb5"),
                        ProductId = Guid.Parse("fb2de661-c885-4957-855f-85ce24ca8323"),
                        IsDeleted = false,
                    };

                    var addcolorVariation1 = context.ProductVariations.Add(colorVariation1).Entity;

                    /************ Variation Options ***************/

                    var colorVariationOpt3 = new VariationOptions()
                    {
                        Id = Guid.Parse("afc39fad-a4f5-40c5-9223-b5c546c8665a"),
                        Name = "Color",
                        Option = "Gray",
                        VariationAttributeId = Guid.Parse("23dd43b1-9880-4ef1-809f-cbb8e26cdbb5"),
                        SKU = "VARPRODUCTRED",
                        Price = 23.56,
                        SalePrice = 21.45,
                        StockQuantity = 5,
                        StockStatus = Enums.StockStatus.InStock,
                        IsDeleted = false,
                    };

                    var addcolorVariationOpt3 = context.VariationOptions.Add(colorVariationOpt3).Entity;


                    var colorVariationOpt4 = new VariationOptions()
                    {
                        Id = Guid.Parse("44b06b52-e4f6-46ff-9866-2ddbeaad7f58"),
                        Name = "Color",
                        Option = "Pink",
                        VariationAttributeId = Guid.Parse("23dd43b1-9880-4ef1-809f-cbb8e26cdbb5"),
                        SKU = "VARPRODUCTGREEN",
                        Price = 22.56,
                        SalePrice = 20.45,
                        StockQuantity = 8,
                        StockStatus = Enums.StockStatus.InStock,
                        IsDeleted = false,
                    };

                    var addcolorVariationOpt4 = context.VariationOptions.Add(colorVariationOpt4).Entity;
                    context.SaveChanges();
                }
            }
        }
    }
}
