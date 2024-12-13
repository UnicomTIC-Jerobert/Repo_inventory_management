using System.ComponentModel.DataAnnotations;

public class ProductPrice
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime DateSet { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}

