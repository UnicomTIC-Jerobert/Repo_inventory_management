using System.ComponentModel.DataAnnotations;

public class ProductPriceResponseDTO
{
    public Guid Id { get; set; }

    public DateTime DateSet { get; set; }

    public decimal Price { get; set; }
}
