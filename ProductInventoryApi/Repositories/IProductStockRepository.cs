public interface IProductStockRepository
{
    Task<IEnumerable<ProductStock>> GetByProductIdAsync(int productId);
    Task<ProductStock> AddAsync(ProductStock productStock);
}
