using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid(); // Automatically generate a new UUID

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<ProductStock> ProductStocks { get; set; }
    public ICollection<ProductPrice> ProductPrices { get; set; }
}

