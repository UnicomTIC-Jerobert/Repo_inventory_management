using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Categories
        // Define GUIDs for consistent relationships
        var guid_category_0001_electronicsId = Guid.NewGuid();
        var guid_category_0002_furnitureId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = guid_category_0001_electronicsId, // Predefined Guid for Electronics
                Name = "Electronics",
                Description = "Electronics items Desc"
            },
            new Category
            {
                Id = guid_category_0002_furnitureId, // Predefined Guid for Furniture
                Name = "Furniture",
                Description = "Furniture items Desc"
            }
        );

        var guid_product_0001_LaptopId = Guid.NewGuid();
        var guid_product_0002_TableId = Guid.NewGuid();
        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = guid_product_0001_LaptopId, // Guid for Product ID
                Name = "Laptop",
                Description = "Gaming Laptop",
                CategoryId = guid_category_0001_electronicsId // Match Electronics category
            },
            new Product
            {
                Id = guid_product_0002_TableId, // Guid for Product ID
                Name = "Table",
                Description = "Dining Table",
                CategoryId = guid_category_0002_furnitureId // Match Furniture category
            }
        );


        // ProductStocks
        modelBuilder.Entity<ProductStock>().HasData(
            new ProductStock { Id = Guid.NewGuid(), ProductId = guid_product_0001_LaptopId, Quantity = 10, DateAdded = DateTime.UtcNow },
            new ProductStock { Id = Guid.NewGuid(), ProductId = guid_product_0002_TableId, Quantity = 5, DateAdded = DateTime.UtcNow },
            new ProductStock { Id = Guid.NewGuid(), ProductId = guid_product_0002_TableId, Quantity = 10, DateAdded = DateTime.UtcNow }
        );

        // ProductPrices
        var guid_productPrice_0001_LaptopId = Guid.NewGuid();
        var guid_productPrice_0002_TableId = Guid.NewGuid();
        var guid_productPrice_0003_LaptopId = Guid.NewGuid();

        modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = guid_productPrice_0001_LaptopId, ProductId = guid_product_0001_LaptopId, Price = 1500 },
            new ProductPrice { Id = guid_productPrice_0002_TableId, ProductId = guid_product_0002_TableId, Price = 200 },
            new ProductPrice { Id = guid_productPrice_0003_LaptopId, ProductId = guid_product_0001_LaptopId, Price = 1600 }
        );



        // Invoices

        var guid_invoice_0001_invoice_1 = Guid.NewGuid();

        modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                Id = guid_invoice_0001_invoice_1,
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
                Id = Guid.NewGuid(),
                InvoiceId = guid_invoice_0001_invoice_1,
                ProductId = guid_product_0001_LaptopId,
                ProductPriceId = guid_productPrice_0003_LaptopId,
                sellingPrice = 1500,
                Qty = 2
            },
             new InvoiceItem
             {
                 Id = Guid.NewGuid(),
                 InvoiceId = guid_invoice_0001_invoice_1,
                 ProductId = guid_product_0002_TableId,
                 ProductPriceId = guid_productPrice_0002_TableId,
                 sellingPrice = 1500,
                 Qty = 2
             }
        );
    }
}
