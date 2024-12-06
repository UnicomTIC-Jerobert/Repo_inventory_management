using System.ComponentModel.DataAnnotations;

public class ProductRequestDTO
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public int CategoryId { get; set; }
}