using System.ComponentModel.DataAnnotations;

public class ProductStockResponseDTO
{
    public Guid Id { get; set; }
   
    public DateTime DateAdded { get; set; }

    public int Quantity { get; set; }
}
