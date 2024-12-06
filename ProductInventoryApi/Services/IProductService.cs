public interface IProductService
{
    Task<APIResponse<IEnumerable<ProductResponseDTO>>> GetAllProductsAsync();
    Task<APIResponse<ProductResponseDTO>> GetProductByIdAsync(int id);
    Task<APIResponse<ProductResponseDTO>> AddProductAsync(ProductRequestDTO dto);
    Task<APIResponse<ProductResponseDTO>> UpdateProductAsync(int id, ProductRequestDTO dto);
    Task<APIResponse<bool>> DeleteProductAsync(int id);
    Task<APIResponse<IEnumerable<ProductPriceDTO>>> GetProductPricesAsync(int productId);
    Task<APIResponse<ProductPriceDTO>> AddProductPriceAsync(int productId, ProductPriceDTO dto);
    Task<APIResponse<IEnumerable<ProductStockDTO>>> GetProductStocksAsync(int productId);
    Task<APIResponse<ProductStockDTO>> AddProductStockAsync(int productId, ProductStockDTO dto);
}
