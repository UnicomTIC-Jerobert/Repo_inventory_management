public class InvoiceItemResponseDTO
{
    public int Guid { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } // Optional for better user experience
    public Guid? ProductPriceId { get; set; }
    public decimal SellingPrice { get; set; }
    public int Qty { get; set; }
    public decimal Subtotal => SellingPrice * Qty; // Optional for API convenience
}
