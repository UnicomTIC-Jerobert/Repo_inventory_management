using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context.Categories.Any() || context.Products.Any())
                return;

            var categories = new List<Category>
            {
                new Category { Name = "Electronics", Description = "Devices and gadgets." },
                new Category { Name = "Furniture", Description = "Home and office furniture." }
            };

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Description = "A high-performance laptop.", Category = categories[0] },
                new Product { Name = "Office Chair", Description = "Ergonomic chair.", Category = categories[1] }
            };

            var productStocks = new List<ProductStock>
            {
                new ProductStock { DateAdded = DateTime.UtcNow, Quantity = 50, Product = products[0] },
                new ProductStock { DateAdded = DateTime.UtcNow, Quantity = 20, Product = products[1] }
            };

            var productPrices = new List<ProductPrice>
            {
                new ProductPrice { DateSet = DateTime.UtcNow, Price = 1200.00M, Product = products[0] },
                new ProductPrice { DateSet = DateTime.UtcNow, Price = 150.00M, Product = products[1] }
            };

            context.Categories.AddRange(categories);
            context.Products.AddRange(products);
            context.ProductStocks.AddRange(productStocks);
            context.ProductPrices.AddRange(productPrices);

            context.SaveChanges();
        }
    }
}
