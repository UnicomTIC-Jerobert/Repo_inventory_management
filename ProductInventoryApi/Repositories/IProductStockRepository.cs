public interface IProductStockRepository
{
    Task<IEnumerable<ProductStock>> GetByProductIdAsync(Guid productId);
    Task<ProductStock> AddAsync(ProductStock productStock);
}
