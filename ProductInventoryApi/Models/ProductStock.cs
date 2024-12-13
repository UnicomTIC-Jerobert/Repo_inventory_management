using System.ComponentModel.DataAnnotations;

public class ProductStock
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime DateAdded { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}

