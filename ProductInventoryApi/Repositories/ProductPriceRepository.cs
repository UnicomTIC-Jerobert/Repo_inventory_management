using Microsoft.EntityFrameworkCore;

public class ProductPriceRepository : IProductPriceRepository
{
    private readonly AppDbContext _context;

    public ProductPriceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductPrice>> GetByProductIdAsync(Guid productId)
    {
        return await _context.ProductPrices
            .Where(pp => pp.ProductId == productId)
            .OrderByDescending(pp => pp.DateSet) // Assuming you want the latest first
            .ToListAsync();
    }

    public async Task<ProductPrice> AddAsync(ProductPrice productPrice)
    {
        await _context.ProductPrices.AddAsync(productPrice);
        await _context.SaveChangesAsync();
        return productPrice;
    }
}
