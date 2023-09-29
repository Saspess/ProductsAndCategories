using ProductsAndCategories.Business.DTOs.Product;

namespace ProductsAndCategories.Business.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewDto>> GetAllAsync();
        Task<IEnumerable<ProductWithCategoryViewDto>> GetWithCategoryAsync();
        Task<IEnumerable<ProductWithCategoryViewDto>> GetByCategoryIdAsync(int categoryId);
        Task<ProductViewDto> GetByIdAsync(int id);
        Task<ProductViewDto> CreateAsync(ProductCreateDto productCreateDto);
        Task UpdateAsync(ProductUpdateDto productUpdateDto);
        Task DeleteAsync(int id);
    }
}
