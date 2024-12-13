public interface IProductPriceRepository
{
    Task<IEnumerable<ProductPrice>> GetByProductIdAsync(Guid productId);
    Task<ProductPrice> AddAsync(ProductPrice productPrice);
}
