using System.ComponentModel.DataAnnotations;


public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid(); // Automatically generate a new UUID

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }
}