using ProductsAndCategories.Business.DTOs.Category;

namespace ProductsAndCategories.Business.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewDto>> GetAllAsync();
        Task<CategoryViewDto> GetByIdAsync(int id);
        Task<CategoryViewDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task DeleteAsync(int id);
    }
}
