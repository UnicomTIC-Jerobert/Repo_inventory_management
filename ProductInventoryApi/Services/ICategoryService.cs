public interface ICategoryService
{
    Task<APIResponse<IEnumerable<CategoryResponseDTO>>> GetAllCategoriesAsync();
    Task<APIResponse<CategoryResponseDTO>> GetCategoryByIdAsync(Guid id);
    Task<APIResponse<CategoryResponseDTO>> AddCategoryAsync(CategoryRequestDTO dto);
    Task<APIResponse<CategoryResponseDTO>> UpdateCategoryAsync(Guid id, CategoryRequestDTO dto);
    Task<APIResponse<bool>> DeleteCategoryAsync(Guid id);
}
