using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics",Description="Electronics items Desc" },
            new Category { Id = 2, Name = "Furniture",Description="Furniture items Desc" }
        );

        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "Gaming Laptop", CategoryId = 1 },
            new Product { Id = 2, Name = "Table", Description = "Dining Table", CategoryId = 2 }
        );

        // ProductStocks
        modelBuilder.Entity<ProductStock>().HasData(
            new ProductStock { Id = 1, ProductId = 1, Quantity = 10, DateAdded = DateTime.UtcNow },
            new ProductStock { Id = 2, ProductId = 2, Quantity = 5, DateAdded = DateTime.UtcNow }
        );

        // ProductPrices
        modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 1, ProductId = 1, Price = 1500 },
            new ProductPrice { Id = 2, ProductId = 2, Price = 200 }
        );

        // Invoices
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                Id = 1,
                Date = DateTime.UtcNow,
                Total = 3000,
                PaidAmount = 2500,
                Balance = 500
            }
        );

        // InvoiceItems
        modelBuilder.Entity<InvoiceItem>().HasData(
            new InvoiceItem
            {
                Id = 1,
                InvoiceId = 1,
                ProductId = 1,
                sellingPrice = 1500,
                Qty = 2
            }
        );
    }
}
