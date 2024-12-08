using Microsoft.EntityFrameworkCore.Storage;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync();
    Task<Invoice> GetByIdAsync(int id);
    Task<Invoice> AddAsync(Invoice invoice);
    Task<Invoice> UpdateAsync(Invoice invoice);
    Task<bool> DeleteAsync(int id);

  Task<IDbContextTransaction> BeginTransactionAsync();
}
