using System.ComponentModel.DataAnnotations;

public class InvoiceItemRequestDTO
{
    [Required]
    public int ProductId { get; set; }

    public int? ProductPriceId { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal SellingPrice { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Qty { get; set; }
}
