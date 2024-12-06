using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class InvoiceItem
{
    public int Id { get; set; }

    [Required]
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal UpdatedProductPrice { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Qty { get; set; }
}
