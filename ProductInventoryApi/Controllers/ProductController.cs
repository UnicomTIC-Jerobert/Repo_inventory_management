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
    public async Task<IActionResult> GetProductById(int id)
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
    public async Task<IActionResult> UpdateProduct(int id, ProductRequestDTO dto)
    {
        var response = await _service.UpdateProductAsync(id, dto);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var response = await _service.DeleteProductAsync(id);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpGet("{productId}/prices")]
    public async Task<IActionResult> GetProductPrices(int productId)
    {
        var response = await _service.GetProductPricesAsync(productId);
        return Ok(response);
    }

    [HttpPost("{productId}/prices")]
    public async Task<IActionResult> AddProductPrice(int productId, ProductPriceDTO dto)
    {
        var response = await _service.AddProductPriceAsync(productId, dto);
        return Created("", response);
    }

    [HttpGet("{productId}/stocks")]
    public async Task<IActionResult> GetProductStocks(int productId)
    {
        var response = await _service.GetProductStocksAsync(productId);
        return Ok(response);
    }

    [HttpPost("{productId}/stocks")]
    public async Task<IActionResult> AddProductStock(int productId, ProductStockDTO dto)
    {
        var response = await _service.AddProductStockAsync(productId, dto);
        return Created("", response);
    }
}
