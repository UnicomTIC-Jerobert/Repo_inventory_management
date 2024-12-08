using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _context.Invoices.Include(i => i.InvoiceItems).ToListAsync();
    }

    public async Task<Invoice> GetByIdAsync(int id)
    {
        return await _context.Invoices
            //.Include(i => i.InvoiceItems)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Invoice> AddAsync(Invoice invoice)
    {
        var created = _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();
        return created.Entity;
    }

    public async Task<Invoice> UpdateAsync(Invoice invoice)
    {
        var updated = _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
        return updated.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null)
            return false;

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}
