public interface IProductService
{
    Task<APIResponse<IEnumerable<ProductResponseDTO>>> GetAllProductsAsync();
    Task<APIResponse<ProductResponseDTO>> GetProductByIdAsync(Guid id);
    Task<APIResponse<ProductResponseDTO>> AddProductAsync(ProductRequestDTO dto);
    Task<APIResponse<ProductResponseDTO>> UpdateProductAsync(Guid id, ProductRequestDTO dto);
    Task<APIResponse<bool>> DeleteProductAsync(Guid id);
    Task<APIResponse<IEnumerable<ProductPriceResponseDTO>>> GetProductPricesAsync(Guid productId);
    Task<APIResponse<ProductPriceResponseDTO>> AddProductPriceAsync(Guid productId, ProductPriceRequestDTO dto);
    Task<APIResponse<IEnumerable<ProductStockResponseDTO>>> GetProductStocksAsync(Guid productId);
    Task<APIResponse<ProductStockResponseDTO>> AddProductStockAsync(Guid productId, ProductStockRequestDTO dto);
}
