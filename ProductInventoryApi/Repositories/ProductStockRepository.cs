using Microsoft.EntityFrameworkCore;

public class ProductStockRepository : IProductStockRepository
{
    private readonly AppDbContext _context;

    public ProductStockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductStock>> GetByProductIdAsync(Guid productId)
    {
        return await _context.ProductStocks
            .Where(ps => ps.ProductId == productId)
            .OrderByDescending(ps => ps.DateAdded) // Assuming you want the latest stock changes first
            .ToListAsync();
    }

    public async Task<ProductStock> AddAsync(ProductStock productStock)
    {
        await _context.ProductStocks.AddAsync(productStock);
        await _context.SaveChangesAsync();
        return productStock;
    }
}
