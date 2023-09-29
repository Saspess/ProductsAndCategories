using AutoMapper;
using ProductsAndCategories.Business.DTOs.Product;
using ProductsAndCategories.Data.Entities;

namespace ProductsAndCategories.Business.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductEntity, ProductViewDto>();

            CreateMap<ProductEntity, ProductWithCategoryViewDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductCreateDto, ProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProductCreateDto, ProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProductUpdateDto, ProductEntity>();
        }
    }
}
