using AutoMapper;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<APIResponse<IEnumerable<CategoryResponseDTO>>> GetAllCategoriesAsync()
    {
        var categories = await _repository.GetAllAsync();
        var categoryDtos = _mapper.Map<IEnumerable<CategoryResponseDTO>>(categories);

        return new APIResponse<IEnumerable<CategoryResponseDTO>>
        {
            Success = true,
            Payload = categoryDtos,
            Title = "Categories retrieved successfully"
        };
    }

    public async Task<APIResponse<CategoryResponseDTO>> GetCategoryByIdAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null)
            return new APIResponse<CategoryResponseDTO>
            {
                Success = false,
                Title = "Category not found",
                Errors = { "The specified category does not exist" }
            };

        var categoryDto = _mapper.Map<CategoryResponseDTO>(category);
        return new APIResponse<CategoryResponseDTO>
        {
            Success = true,
            Payload = categoryDto,
            Title = "Category retrieved successfully"
        };
    }

    public async Task<APIResponse<CategoryResponseDTO>> AddCategoryAsync(CategoryRequestDTO dto)
    {
        var category = _mapper.Map<Category>(dto);
        var createdCategory = await _repository.AddAsync(category);
        var categoryDto = _mapper.Map<CategoryResponseDTO>(createdCategory);

        return new APIResponse<CategoryResponseDTO>
        {
            Success = true,
            Payload = categoryDto,
            Title = "Category added successfully"
        };
    }

    public async Task<APIResponse<CategoryResponseDTO>> UpdateCategoryAsync(Guid id, CategoryRequestDTO dto)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null)
            return new APIResponse<CategoryResponseDTO>
            {
                Success = false,
                Title = "Category not found",
                Errors = { "The specified category does not exist" }
            };

        category.Name = dto.Name;
        category.Description = dto.Description;

        var updatedCategory = await _repository.UpdateAsync(category);
        var categoryDto = _mapper.Map<CategoryResponseDTO>(updatedCategory);

        return new APIResponse<CategoryResponseDTO>
        {
            Success = true,
            Payload = categoryDto,
            Title = "Category updated successfully"
        };
    }

    public async Task<APIResponse<bool>> DeleteCategoryAsync(Guid id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted)
            return new APIResponse<bool>
            {
                Success = false,
                Title = "Deletion failed",
                Errors = { "Category not found or already deleted" }
            };

        return new APIResponse<bool>
        {
            Success = true,
            Payload = true,
            Title = "Category deleted successfully"
        };
    }
}
