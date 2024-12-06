public interface IProductPriceRepository
{
    Task<IEnumerable<ProductPrice>> GetByProductIdAsync(int productId);
    Task<ProductPrice> AddAsync(ProductPrice productPrice);
}
