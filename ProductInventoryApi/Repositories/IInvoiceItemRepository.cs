public interface IInvoiceItemRepository
{
    Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(Guid invoiceId);
    Task<InvoiceItem> AddAsync(InvoiceItem invoiceItem);
    Task<bool> DeleteByInvoiceIdAsync(Guid invoiceId);
}
