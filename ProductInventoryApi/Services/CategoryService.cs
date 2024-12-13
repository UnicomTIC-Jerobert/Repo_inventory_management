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
        IEnumerable<Category> categories = await _repository.GetAllAsync();
        IEnumerable<CategoryResponseDTO> categoryResponseDtos = _mapper.Map<IEnumerable<CategoryResponseDTO>>(categories);

        return new APIResponse<IEnumerable<CategoryResponseDTO>>
        {
            Success = true,
            Payload = categoryResponseDtos,
            Title = "Categories retrieved successfully"
        };
    }

    public async Task<APIResponse<CategoryResponseDTO>> GetCategoryByIdAsync(Guid id)
    {
        Category category = await _repository.GetByIdAsync(id);
        if (category == null)
            return new APIResponse<CategoryResponseDTO>
            {
                Success = false,
                Title = "Category not found",
                Errors = { "The specified category does not exist" }
            };

        CategoryResponseDTO categoryResponseDto = _mapper.Map<CategoryResponseDTO>(category);
        return new APIResponse<CategoryResponseDTO>
        {
            Success = true,
            Payload = categoryResponseDto,
            Title = "Category retrieved successfully"
        };
    }

    public async Task<APIResponse<CategoryResponseDTO>> AddCategoryAsync(CategoryRequestDTO categoryRequestDto)
    {
        Category category = _mapper.Map<Category>(categoryRequestDto);
        Category createdCategory = await _repository.AddAsync(category);
        CategoryResponseDTO categoryResponseDto = _mapper.Map<CategoryResponseDTO>(createdCategory);

        return new APIResponse<CategoryResponseDTO>
        {
            Success = true,
            Payload = categoryResponseDto,
            Title = "Category added successfully"
        };
    }

    public async Task<APIResponse<CategoryResponseDTO>> UpdateCategoryAsync(Guid id, CategoryRequestDTO categoryRequestDTO)
    {
        Category category = await _repository.GetByIdAsync(id);
        if (category == null)
            return new APIResponse<CategoryResponseDTO>
            {
                Success = false,
                Title = "Category not found",
                Errors = { "The specified category does not exist" }
            };

        category.Name = categoryRequestDTO.Name;
        category.Description = categoryRequestDTO.Description;

        Category updatedCategory = await _repository.UpdateAsync(category);
        CategoryResponseDTO categoryResponseDto = _mapper.Map<CategoryResponseDTO>(updatedCategory);

        return new APIResponse<CategoryResponseDTO>
        {
            Success = true,
            Payload = categoryResponseDto,
            Title = "Category updated successfully"
        };
    }

    public async Task<APIResponse<bool>> DeleteCategoryAsync(Guid id)
    {
        bool deleted = await _repository.DeleteAsync(id);
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
