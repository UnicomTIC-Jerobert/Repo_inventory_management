using System.ComponentModel.DataAnnotations;

public class ProductStockDTO
{
    [Required]
    public DateTime DateAdded { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
