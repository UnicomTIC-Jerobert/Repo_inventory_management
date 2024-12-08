public class InvoiceResponseDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal Balance { get; set; }
    public List<InvoiceItemResponseDTO> InvoiceItems { get; set; }
}
