public interface ICategoryService
{
    Task<APIResponse<IEnumerable<CategoryResponseDTO>>> GetAllCategoriesAsync();
    Task<APIResponse<CategoryResponseDTO>> GetCategoryByIdAsync(int id);
    Task<APIResponse<CategoryResponseDTO>> AddCategoryAsync(CategoryRequestDTO dto);
    Task<APIResponse<CategoryResponseDTO>> UpdateCategoryAsync(int id, CategoryRequestDTO dto);
    Task<APIResponse<bool>> DeleteCategoryAsync(int id);
}
