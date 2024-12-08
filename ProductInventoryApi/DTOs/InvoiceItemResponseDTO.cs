public class InvoiceItemResponseDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } // Optional for better user experience
    public int? ProductPriceId { get; set; }
    public decimal SellingPrice { get; set; }
    public int Qty { get; set; }
    public decimal Subtotal => SellingPrice * Qty; // Optional for API convenience
}
