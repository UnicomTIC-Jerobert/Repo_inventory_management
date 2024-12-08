using System.ComponentModel.DataAnnotations;

public class InvoiceRequestDTO
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal PaidAmount { get; set; }

    public List<InvoiceItemRequestDTO> InvoiceItems { get; set; }
}
