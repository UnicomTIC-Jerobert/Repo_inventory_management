using System.ComponentModel.DataAnnotations;

public class ProductPrice
{
    public int Id { get; set; }

    [Required]
    public DateTime DateSet { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}

