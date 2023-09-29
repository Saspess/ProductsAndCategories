using AutoMapper;
using ProductsAndCategories.Business.DTOs.Category;
using ProductsAndCategories.Data.Entities;

namespace ProductsAndCategories.Business.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryEntity, CategoryViewDto>();

            CreateMap<CategoryCreateDto, CategoryEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CategoryUpdateDto, CategoryEntity>();
        }
    }
}
