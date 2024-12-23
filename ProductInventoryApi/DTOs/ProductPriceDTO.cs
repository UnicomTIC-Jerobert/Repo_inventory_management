using System.ComponentModel.DataAnnotations;

public class ProductPriceDTO
{
    [Required]
    public DateTime DateSet { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
}
