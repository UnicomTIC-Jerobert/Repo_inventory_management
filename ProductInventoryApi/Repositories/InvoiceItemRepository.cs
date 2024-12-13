using Microsoft.EntityFrameworkCore;

public class InvoiceItemRepository : IInvoiceItemRepository
{
    private readonly AppDbContext _context;

    public InvoiceItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(Guid invoiceId)
    {
        return await _context.InvoiceItems
            .Include(ii => ii.Product)
            .Where(ii => ii.InvoiceId == invoiceId)
            .ToListAsync();
    }

    public async Task<InvoiceItem> AddAsync(InvoiceItem invoiceItem)
    {
        _context.InvoiceItems.Add(invoiceItem);
        await _context.SaveChangesAsync();
        return invoiceItem;
    }

    public async Task<bool> DeleteByInvoiceIdAsync(Guid invoiceId)
    {
        var items = _context.InvoiceItems.Where(ii => ii.InvoiceId == invoiceId);
        if (!items.Any()) return false;

        _context.InvoiceItems.RemoveRange(items);
        await _context.SaveChangesAsync();
        return true;
    }
}
