using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var response = await _service.GetAllCategoriesAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var response = await _service.GetCategoryByIdAsync(id);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryRequestDTO dto)
    {
        var response = await _service.AddCategoryAsync(dto);
        return CreatedAtAction(nameof(GetCategoryById), new { id = response.Payload.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id, CategoryRequestDTO dto)
    {
        var response = await _service.UpdateCategoryAsync(id, dto);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var response = await _service.DeleteCategoryAsync(id);
        if (!response.Success) return NotFound(response);
        return Ok(response);
    }
}
