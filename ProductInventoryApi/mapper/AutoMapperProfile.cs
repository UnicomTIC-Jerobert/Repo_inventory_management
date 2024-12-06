using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryResponseDTO>();
        CreateMap<CategoryRequestDTO, Category>();

        // Product Mapping
        CreateMap<Product, ProductResponseDTO>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ProductRequestDTO, Product>();

        // ProductPrice Mapping
        CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();

        // ProductStock Mapping
        CreateMap<ProductStock, ProductStockDTO>().ReverseMap();
    }
}
