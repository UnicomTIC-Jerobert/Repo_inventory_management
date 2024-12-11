using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category and Product
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Product and ProductStock
        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductStocks)
            .WithOne(ps => ps.Product)
            .HasForeignKey(ps => ps.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Product and ProductPrice
        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductPrices)
            .WithOne(pp => pp.Product)
            .HasForeignKey(pp => pp.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Invoice -> InvoiceItem
        modelBuilder.Entity<Invoice>()
            .HasMany(i => i.InvoiceItems)
            .WithOne(ii => ii.Invoice)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // InvoiceItem -> Product
        modelBuilder.Entity<InvoiceItem>()
            .HasOne(ii => ii.Product)
            .WithMany()
            .HasForeignKey(ii => ii.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // InvoiceItem -> ProductPrice (Optional)
        modelBuilder.Entity<InvoiceItem>()
            .HasOne(ii => ii.ProductPrice)
            .WithMany()
            .HasForeignKey(ii => ii.ProductPriceId)
            .OnDelete(DeleteBehavior.Restrict);

        SeedData.Seed(modelBuilder);
    }



}
