using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class InvoiceItem
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid? ProductPriceId { get; set; }
    public ProductPrice ProductPrice { get; set; }

    // this selling price must math with ProductPriceId while audit , but for discounts we can do modification & judments
    [Required]
    [Range(0, double.MaxValue)]
    public decimal sellingPrice { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Qty { get; set; }
}
