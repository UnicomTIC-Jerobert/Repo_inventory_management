public interface IInvoiceItemRepository
{
    Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(int invoiceId);
    Task<InvoiceItem> AddAsync(InvoiceItem invoiceItem);
    Task<bool> DeleteByInvoiceIdAsync(int invoiceId);
}
