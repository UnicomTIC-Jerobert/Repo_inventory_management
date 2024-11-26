using System.ComponentModel.DataAnnotations;


public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }
}