using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _service.GetAllProductsAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var response = await _service.GetProductByIdAsync(id);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductRequestDTO dto)
    {
        var response = await _service.AddProductAsync(dto);
        return CreatedAtAction(nameof(GetProductById), new { id = response.Payload.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, ProductRequestDTO dto)
    {
        var response = await _service.UpdateProductAsync(id, dto);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var response = await _service.DeleteProductAsync(id);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpGet("{productId}/prices")]
    public async Task<IActionResult> GetProductPrices(Guid productId)
    {
        var response = await _service.GetProductPricesAsync(productId);
        return Ok(response);
    }

    [HttpPost("{productId}/prices")]
    public async Task<IActionResult> AddProductPrice(Guid productId, ProductPriceRequestDTO dto)
    {
        var response = await _service.AddProductPriceAsync(productId, dto);
        return Created("", response);
    }

    [HttpGet("{productId}/stocks")]
    public async Task<IActionResult> GetProductStocks(Guid productId)
    {
        var response = await _service.GetProductStocksAsync(productId);
        return Ok(response);
    }

    [HttpPost("{productId}/stocks")]
    public async Task<IActionResult> AddProductStock(Guid productId, ProductStockRequestDTO dto)
    {
        var response = await _service.AddProductStockAsync(productId, dto);
        return Created("", response);
    }
}
