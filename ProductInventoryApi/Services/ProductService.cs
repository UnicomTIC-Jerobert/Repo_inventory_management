using AutoMapper;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepo;
    private readonly IProductPriceRepository _priceRepo;
    private readonly IProductStockRepository _stockRepo;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepo,
        IProductPriceRepository priceRepo,
        IProductStockRepository stockRepo,
        IMapper mapper)
    {
        _productRepo = productRepo;
        _priceRepo = priceRepo;
        _stockRepo = stockRepo;
        _mapper = mapper;
    }

    public async Task<APIResponse<IEnumerable<ProductResponseDTO>>> GetAllProductsAsync()
    {
        var products = await _productRepo.GetAllAsync();
        var productDtos = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);

        return new APIResponse<IEnumerable<ProductResponseDTO>>
        {
            Success = true,
            Payload = productDtos,
            Title = "Products retrieved successfully"
        };
    }

    public async Task<APIResponse<ProductResponseDTO>> GetProductByIdAsync(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            return new APIResponse<ProductResponseDTO>
            {
                Success = false,
                Title = "Product not found",
                Errors = { "The specified product does not exist" }
            };

        var productDto = _mapper.Map<ProductResponseDTO>(product);
        return new APIResponse<ProductResponseDTO>
        {
            Success = true,
            Payload = productDto,
            Title = "Product retrieved successfully"
        };
    }

    public async Task<APIResponse<ProductResponseDTO>> AddProductAsync(ProductRequestDTO dto)
    {
        var product = _mapper.Map<Product>(dto);
        var createdProduct = await _productRepo.AddAsync(product);
        var productDto = _mapper.Map<ProductResponseDTO>(createdProduct);

        return new APIResponse<ProductResponseDTO>
        {
            Success = true,
            Payload = productDto,
            Title = "Product added successfully"
        };
    }

    public async Task<APIResponse<ProductResponseDTO>> UpdateProductAsync(int id, ProductRequestDTO dto)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            return new APIResponse<ProductResponseDTO>
            {
                Success = false,
                Title = "Product not found",
                Errors = { "The specified product does not exist" }
            };

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.CategoryId = dto.CategoryId;

        var updatedProduct = await _productRepo.UpdateAsync(product);
        var productDto = _mapper.Map<ProductResponseDTO>(updatedProduct);

        return new APIResponse<ProductResponseDTO>
        {
            Success = true,
            Payload = productDto,
            Title = "Product updated successfully"
        };
    }

    public async Task<APIResponse<bool>> DeleteProductAsync(int id)
    {
        var deleted = await _productRepo.DeleteAsync(id);
        if (!deleted)
            return new APIResponse<bool>
            {
                Success = false,
                Title = "Deletion failed",
                Errors = { "Product not found or already deleted" }
            };

        return new APIResponse<bool>
        {
            Success = true,
            Payload = true,
            Title = "Product deleted successfully"
        };
    }

    public async Task<APIResponse<IEnumerable<ProductPriceDTO>>> GetProductPricesAsync(int productId)
    {
        var prices = await _priceRepo.GetByProductIdAsync(productId);
        var priceDtos = _mapper.Map<IEnumerable<ProductPriceDTO>>(prices);

        return new APIResponse<IEnumerable<ProductPriceDTO>>
        {
            Success = true,
            Payload = priceDtos,
            Title = "Product prices retrieved successfully"
        };
    }

    public async Task<APIResponse<ProductPriceDTO>> AddProductPriceAsync(int productId, ProductPriceDTO dto)
    {
        var price = _mapper.Map<ProductPrice>(dto);
        price.ProductId = productId;

        var createdPrice = await _priceRepo.AddAsync(price);
        var priceDto = _mapper.Map<ProductPriceDTO>(createdPrice);

        return new APIResponse<ProductPriceDTO>
        {
            Success = true,
            Payload = priceDto,
            Title = "Product price added successfully"
        };
    }

    public async Task<APIResponse<IEnumerable<ProductStockDTO>>> GetProductStocksAsync(int productId)
    {
        var stocks = await _stockRepo.GetByProductIdAsync(productId);
        var stockDtos = _mapper.Map<IEnumerable<ProductStockDTO>>(stocks);

        return new APIResponse<IEnumerable<ProductStockDTO>>
        {
            Success = true,
            Payload = stockDtos,
            Title = "Product stocks retrieved successfully"
        };
    }

    public async Task<APIResponse<ProductStockDTO>> AddProductStockAsync(int productId, ProductStockDTO dto)
    {
        var stock = _mapper.Map<ProductStock>(dto);
        stock.ProductId = productId;

        var createdStock = await _stockRepo.AddAsync(stock);
        var stockDto = _mapper.Map<ProductStockDTO>(createdStock);

        return new APIResponse<ProductStockDTO>
        {
            Success = true,
            Payload = stockDto,
            Title = "Product stock added successfully"
        };
    }
}
